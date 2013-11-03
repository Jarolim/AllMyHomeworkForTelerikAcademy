using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using MusicStore.Model;
using System.Net.Http.Headers;

namespace MusicStore.Client
{
    internal class ConsoleClient
    {
        private static readonly HttpClient Client = new HttpClient { BaseAddress = new Uri("http://localhost:50541/") };

        private static IList<Artist> allArtists = new List<Artist>();
        private static IList<Artist> AllArtists
        {
            get
            {

                if (allArtists.Count == 0)
                {
                    Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    HttpResponseMessage response = Client.GetAsync("api/Artists").Result;
                    if (response.IsSuccessStatusCode)
                    {
                        var artists = response.Content.ReadAsAsync<IEnumerable<Artist>>().Result;
                        foreach (var artist in artists)
                        {
                            allArtists.Add(artist);
                        }
                    }
                    else
                    {
                        throw new ArgumentException(string.Format("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase));
                    }
                }

                return allArtists;
            }
        }

        #region Add

        internal static void AddNewArtist(string name, string country, DateTime? dateOfBirth, string applicationType)
        {
            if (AllArtists.Any(x => x.ArtistName == name))
            {
                Console.WriteLine("Artist already exists.");
                return;
            }

            // Add an Accept header for JSON format.
            Client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue(applicationType));

            var artist = new Artist
            {
                ArtistName = name,
                Country = country,
                DateOfBirth = dateOfBirth,
            };

            HttpResponseMessage response = null;

            if (applicationType == "application/json")
            {
                response = Client.PostAsJsonAsync("api/Artists", artist).Result;
            }
            else
            {
                response = Client.PostAsXmlAsync("api/Artists", artist).Result;

            }

            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Artist added!");
                int artistID = int.Parse(response.Headers.Location.Segments[3]);
                artist.ArtistId = artistID;
                allArtists.Add(artist);
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
        }

        internal static void AddNewAlbum(string title, string producer, int? year, string applicationType, string artistName)
        {
            Artist artist = AllArtists.FirstOrDefault(a => a.ArtistName == artistName);
            if (artist == null)
            {
                Console.WriteLine("Artist doesn't exist.");
                return;
            }

            // Add an Accept header for JSON format.
            Client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue(applicationType));

            var album = new Album
            {
                AlbumTitle = title,
                AlbumYear = year,
                Producer = producer
            };

            album.Artists.Add(artist);

            HttpResponseMessage response = null;

            if (applicationType == "application/json")
            {
                response = Client.PostAsJsonAsync("api/Albums", album).Result;
            }
            else
            {
                response = Client.PostAsXmlAsync("api/Albums", album).Result;
            }

            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Album added!");
                int albumID = int.Parse(response.Headers.Location.Segments[3]);
                album.AlbumId = albumID;
                artist.Albums.Add(album);
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
        }

        internal static void AddNewSong(string title, int year, string genre, string applicationType, string artistName, string albumTitle)
        {
            Artist artist = AllArtists.FirstOrDefault(a => a.ArtistName == artistName);
            if (artist == null)
            {
                Console.WriteLine("Artist doesn't exist.");
                return;
            }

            Album album = artist.Albums.FirstOrDefault(a => a.AlbumTitle == albumTitle);
            if (album == null)
            {
                Console.WriteLine("Artist dosn't have such an album.");
                return;
            }

            // Add an Accept header for JSON format.
            Client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue(applicationType));

            var song = new Song
            {
                SongTitle = title,
                SongYear = year,
                Genre = genre,
            };

            song.Albums.Add(album);
            song.Artist = artist;
            song.ArtistId = artist.ArtistId;
            HttpResponseMessage response = null;

            if (applicationType == "application/json")
            {
                response = Client.PostAsJsonAsync("api/Songs", song).Result;
            }
            else
            {
                response = Client.PostAsXmlAsync("api/Songs", song).Result;
            }

            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Song added!");
                int songID = int.Parse(response.Headers.Location.Segments[3]);
                song.SongId = songID;
                artist.Songs.Add(song);
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
        }

        #endregion

        #region Delete

        private static void DeleteArtist(string name)
        {
            var artists = AllArtists.Where(a => a.ArtistName == name);

            foreach (var artist in artists)
            {
                Client.DeleteAsync("api/Artists/" + artist.ArtistId);
            }
        }

        private static void DeleteAlbum(string title)
        {
            var artists = AllArtists.Where(ar => ar.Albums.Any(al => al.AlbumTitle == title));

            List<int> albumIdsToDelete = new List<int>();

            foreach (var artist in artists)
            {
                foreach (var album in artist.Albums.Where(al => al.AlbumTitle == title))
                {
                    Client.DeleteAsync("api/Albums/" + album.AlbumId);
                    albumIdsToDelete.Add(album.AlbumId);
                }

                for (int i = 0; i < albumIdsToDelete.Count; i++)
                {
                    artist.Albums.Remove(artist.Albums.FirstOrDefault(al => al.AlbumId == albumIdsToDelete[i]));
                }
            }
        }

        private static void DeleteSong(string title)
        {
            var artists = AllArtists.Where(a => a.Songs.Any(s => s.SongTitle == title));

            List<int> songIdsToDelete = new List<int>();

            foreach (var artist in artists)
            {
                foreach (var song in artist.Songs.Where(s => s.SongTitle == title))
                {
                    Client.DeleteAsync("api/Songs/" + song.SongId);
                    songIdsToDelete.Add(song.SongId);
                }

                for (int i = 0; i < songIdsToDelete.Count; i++)
                {
                    artist.Songs.Remove(artist.Songs.FirstOrDefault(s => s.SongId == songIdsToDelete[i]));
                }
            }
        }

        #endregion

        #region Update

        private static void UpdateAlbum(string artistName, string title, string newTitle, int? year, string producer, string applicationType)
        {
            if (string.IsNullOrWhiteSpace(title))
            {
                Console.WriteLine("Album title cannot be empty.");
            }

            var artist = AllArtists.FirstOrDefault(a => a.ArtistName == artistName);

            if (artist == null)
            {
                Console.WriteLine("No such artist.");
            }

            var album = artist.Albums.FirstOrDefault(a => a.AlbumTitle == title);

            if (album == null)
            {
                Console.WriteLine("No such album.");
            }

            var modelAlbum = new Album
            {
                AlbumTitle = newTitle,
                AlbumYear = year,
                Producer = producer
            };

            HttpResponseMessage response = null;

            if (applicationType == "application/json")
            {
                response = Client.PutAsJsonAsync("api/Albums/" + album.AlbumId, modelAlbum).Result;
            }
            else
            {
                response = Client.PutAsXmlAsync("api/Albums/" + album.AlbumId, modelAlbum).Result;
            }

            if (response.IsSuccessStatusCode)
            {
                album.AlbumTitle = modelAlbum.AlbumTitle ?? album.AlbumTitle;
                album.AlbumYear = modelAlbum.AlbumYear ?? album.AlbumYear;
                album.Producer = modelAlbum.Producer ?? album.Producer;
                Console.WriteLine("Album updated!");
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
        }

        private static void UpdateSong(string artistName, string title, string newTitle, int? year, string genre, string applicationType)
        {
            if (string.IsNullOrWhiteSpace(title))
            {
                Console.WriteLine("Song title cannot be empty.");
            }

            var artist = AllArtists.FirstOrDefault(a => a.ArtistName == artistName);

            if (artist == null)
            {
                Console.WriteLine("No such artist.");
            }

            var song = artist.Songs.FirstOrDefault(s => s.SongTitle == title);

            if (song == null)
            {
                Console.WriteLine("No such song.");
            }

            var modelSong = new Song
            {
                SongTitle = newTitle,
                SongYear = year,
                Genre = genre
            };

            HttpResponseMessage response = null;

            if (applicationType == "application/json")
            {
                response = Client.PutAsJsonAsync("api/Songs/" + song.SongId, modelSong).Result;
            }
            else
            {
                response = Client.PutAsXmlAsync("api/Songs/" + song.SongId, modelSong).Result;
            }

            if (response.IsSuccessStatusCode)
            {
                song.SongTitle = modelSong.SongTitle ?? song.SongTitle;
                song.SongYear = modelSong.SongYear ?? song.SongYear;
                song.Genre = modelSong.Genre ?? song.Genre;
                Console.WriteLine("Song updated!");
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
        }

        private static void UpdateArtist(string name, string newName, string country, DateTime? dateOfBirth, string applicationType)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                Console.WriteLine("Artist name cannot be empty.");
            }

            var artist = AllArtists.FirstOrDefault(a => a.ArtistName == name);

            if (artist == null)
            {
                Console.WriteLine("No such artist.");
            }

            var modelArtist = new Artist
            {
                ArtistName = newName,
                Country = country,
                DateOfBirth = dateOfBirth
            };

            HttpResponseMessage response = null;

            if (applicationType == "application/json")
            {
                response = Client.PutAsJsonAsync("api/Artists/" + artist.ArtistId, modelArtist).Result;
            }
            else
            {
                response = Client.PutAsXmlAsync("api/Artists/" + artist.ArtistId, modelArtist).Result;
            }

            if (response.IsSuccessStatusCode)
            {
                artist.ArtistName = modelArtist.ArtistName ?? artist.ArtistName;
                artist.Country = modelArtist.Country ?? artist.Country;
                artist.DateOfBirth = modelArtist.DateOfBirth ?? artist.DateOfBirth;
                Console.WriteLine("Artist updated!");
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
        }

        #endregion

        #region Get

        private static void GetAllArtists()
        {
            foreach (var artist in AllArtists)
            {
                Console.WriteLine(
                    "Name: {0}, Country: {1}, DateOfBirth: {2}",
                    artist.ArtistName,
                    artist.Country,
                    artist.DateOfBirth);
            }
        }

        private static void GetAllAlbums()
        {
            foreach (var artist in AllArtists)
            {
                foreach (var album in artist.Albums)
                {
                    Console.WriteLine(
                        "Title: {0}, Year: {1}, Producer: {2}",
                        album.AlbumTitle,
                        album.AlbumYear,
                        album.Producer);
                }
            }
        }

        private static void GetAllSongs()
        {
            foreach (var artist in AllArtists)
            {
                foreach (var song in artist.Songs)
                {
                    Console.WriteLine(
                        "Title: {0}, Year: {1}, Genre: {2}",
                        song.SongTitle,
                        song.SongYear,
                        song.Genre);
                }
            }
        }

        #endregion

        private static void Main()
        {
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/xml"));

            //AddNewArtist("Merilyn Monroe", "Mexico", new DateTime(1940, 10, 13), "application/xml");
            //AddNewAlbum("Forever", "EMI", 1998, "application/json", "Merilyn Monroe");
            //AddNewSong("Tonight", 1999, "pop", "application/xml", "Merilyn Monroe", "Forever");
            
            //DeleteSong("Season love");
            //DeleteAlbum("Forever");
            //DeleteArtist("Tina Turner");
            
            //UpdateSong("Merilyn Monroe", "Alabala", "Hush", 2013, null, "application/xml");
            //UpdateAlbum("Merilyn Monroe", "Forever", "Never", 1337, "Payner", "application/json");
            //UpdateArtist("Merilyn Monroe", "Norma Jeane Mortenson", "USA", null, "application/json");
            
            //GetAllArtists();
            //GetAllAlbums();
            GetAllSongs();

        }
    }
}

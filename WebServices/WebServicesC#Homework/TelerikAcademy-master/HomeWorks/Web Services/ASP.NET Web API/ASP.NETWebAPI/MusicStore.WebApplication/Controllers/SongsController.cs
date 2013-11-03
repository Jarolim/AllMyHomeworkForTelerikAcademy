using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Linq;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using MusicStore.Model;
using Newtonsoft.Json;

namespace MusicStoreWebApplication.Controllers
{
    public class SongsController : ApiController
    {
        private MusicStoreEntities db = new MusicStoreEntities();

        public SongsController()
        {
            db.Configuration.ProxyCreationEnabled = false;
        }

        // GET api/Songs
        public IEnumerable<Song> GetSongs()
        {
            var songs =
                (from song in db.Songs.Include(s => s.Artist)
                 select new
                 {
                     Artist = song.Artist,
                     SongTitle = song.SongTitle,
                     SongYear = song.SongYear,
                     Genre = song.Genre
                 }).ToList()
                 .Select(s => new Song
                 {
                     Artist = s.Artist,
                     SongTitle = s.SongTitle,
                     SongYear = s.SongYear,
                     Genre = s.Genre
                 }).AsEnumerable();

            return songs;
        }

        // GET api/Songs/5
        public Song GetSong(int id)
        {
            Song song = db.Songs.Find(id);
            if (song == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return song;
        }

        // PUT api/Songs/5
        public HttpResponseMessage PutSong(int id, Song song)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            var songToUpdate = db.Songs.FirstOrDefault(a => a.SongId == id);

            if (songToUpdate != null && song != null)
            {
                songToUpdate.SongTitle = song.SongTitle ?? songToUpdate.SongTitle;
                songToUpdate.SongYear = song.SongYear ?? songToUpdate.SongYear;
                songToUpdate.Genre = song.Genre ?? songToUpdate.Genre;
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            db.Entry(songToUpdate).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        // POST api/Songs
        public HttpResponseMessage PostSong(Song song)
        {
            
            if (ModelState.IsValid)
            {
                CheckAlbumsInSong(song);
                var artist = db.Artists.FirstOrDefault(x => x.ArtistId == song.ArtistId);

                song.Artist = artist;
                db.Songs.Add(song);
                db.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, song);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = song.SongId }));
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        // DELETE api/Songs/5
        public HttpResponseMessage DeleteSong(int id)
        {
            Song song = db.Songs.Find(id);
            if (song == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.Songs.Remove(song);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK, song);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

        private void CheckAlbumsInSong(Song song)
        {
            var albums = new List<Album>();
            song.Albums.ToList().ForEach(album =>
            {
                var a = db.Albums.FirstOrDefault(x => x.AlbumId == album.AlbumId);
                //if (a == null)
                //{
                //    a = new Album();
                //    a.AlbumTitle = album.AlbumTitle;
                //}
                albums.Add(a);
            });
            song.Albums = albums;
        }
    }
}
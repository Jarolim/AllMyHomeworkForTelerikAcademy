using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CatalogOfFreeContent;

namespace FreeContentCatalog.Tests
{
    [TestClass]
    public class CatalogTests
    {
        [TestMethod]
        public void TestMethod_AddSingleItem()
        {
            Catalog catalog = new Catalog();

            Content book = new Content(ContentType.Book, 
                new string[] {"Intro C#", "S.Nakov", 
                    "12763892", "http://www.introprogramming.info"});

            catalog.Add(book);

            Assert.AreEqual(1, catalog.Count);

            //var result = catalog.GetListContent("Intro C#", 1);
            //
            //Assert.AreEqual(result.Count(), 1);
            //Assert.AreSame(result.First(), book);
        }

        [TestMethod]
        public void TestMethod_AddSingleItemAndCheckContent()
        {
            Catalog catalog = new Catalog();

            Content book = new Content(ContentType.Book,
                new string[] {"Intro C#", "S.Nakov", 
                    "12763892", "http://www.introprogramming.info"});

            catalog.Add(book);

            var result = catalog.GetListContent("Intro C#", 1);
            
            Assert.AreEqual(result.Count(), 1);
            Assert.AreSame(result.First(), book);
        }

        [TestMethod]
        public void TestMethod_AddDuplicatedItem()
        {
            Catalog catalog = new Catalog();

            Content book1 = new Content(ContentType.Book,
                new string[] {"Intro C#", "S.Nakov", 
                    "12763892", "http://www.introprogramming.info"});
            catalog.Add(book1);
            catalog.Add(book1);

            Content book2 = new Content(ContentType.Book,
                new string[] {"Intro C#", "S.Nakov", 
                    "12763892", "http://www.introprogramming.info"});

            
            catalog.Add(book2);

            Assert.AreEqual(3, catalog.Count);
        }

        [TestMethod]
        public void TestMethod_AddMultipleItem()
        {
            Catalog catalog = new Catalog();

            Content book1 = new Content(ContentType.Book,
                new string[] {"Intro C#", "S.Nakov", 
                    "12763892", "http://www.introprogramming.info"});
            catalog.Add(book1);

            Content movie = new Content(ContentType.Book,
                new string[] {"Java Movie", "S.sssss", 
                    "12755892", "http://www.introprogramming.com"});

            catalog.Add(movie);

            Content song = new Content(ContentType.Book,
                new string[] {"Java song", "S.sssss", 
                    "12755892", "http://www.introprogramming.bg"});

            catalog.Add(song);

            Assert.AreEqual(3, catalog.Count);
        }

        //Performance test
        [TestMethod]
        [Timeout(500)]
        public void TestMethod_Add10000Item()
        {
            Catalog catalog = new Catalog();

            for (int i = 0; i < 10000; i++)
            {
                Content book1 = new Content(ContentType.Book,
                new string[] {"Intro C#" + (i%5), "S.Nakov", 
                    "12763892", "http://www.introprogramming.info"});
                catalog.Add(book1);
            }

            Assert.AreEqual(10000, catalog.Count);
        }




        //////////////////////////////////////////////////////////

        [TestMethod]
        public void TestMethod_GetListContentSingleItems()
        {
            Catalog catalog = new Catalog();

            Content book = new Content(ContentType.Book,
                new string[] {"Intro C#", "S.Nakov", 
                    "12763892", "http://www.introprogramming.bg"});

            catalog.Add(book);

            Content movie = new Content(ContentType.Movie,
                new string[] {"Intro movie", "S.Nakov", 
                    "12763892", "http://www.bg.info"});

            catalog.Add(movie);

            Content app = new Content(ContentType.Application,
                new string[] {"Intro movie", "S.Nakov", 
                    "12763892", "http://www.bg.info"});

            catalog.Add(app);

            var result = catalog.GetListContent("Intro C#", 10);

            Assert.AreEqual(result.Count(), 1);
            Assert.AreSame(result.First(), book);
        }

        [TestMethod]
        public void TestMethod_GetListContentTwoItems()
        {
            Catalog catalog = new Catalog();

            Content book = new Content(ContentType.Book,
                new string[] {"Intro C#", "S.Nakov", 
                    "12763892", "http://www.introprogramming.bg"});

            catalog.Add(book);

            Content movie = new Content(ContentType.Movie,
                new string[] {"Intro movie", "S.Nakov", 
                    "12763892", "http://www.bg.info"});

            catalog.Add(movie);

            Content app = new Content(ContentType.Application,
                new string[] {"Intro movie", "S.Nakov", 
                    "12763892", "http://www.bg.info"});

            catalog.Add(app);

            var result = catalog.GetListContent("Intro movie", 10);

            Assert.AreEqual(result.Count(), 2);
        }

        [TestMethod]
        public void TestMethod_GetListContentManyMatchingItemsFirstOnly()
        {
            Catalog catalog = new Catalog();

            Content book = new Content(ContentType.Book,
                new string[] {"Intro C#", "S.Nakov", 
                    "12763892", "http://www.introprogramming.bg"});

            catalog.Add(book);

            Content movie = new Content(ContentType.Movie,
                new string[] {"Intro movie", "S.Nakov", 
                    "12763892", "http://www.bg.info"});

            catalog.Add(movie);

            Content app = new Content(ContentType.Application,
                new string[] {"Intro movie", "S.Nakov", 
                    "12763892", "http://www.bg.info"});

            catalog.Add(app);

            var result = catalog.GetListContent("Intro movie", 1);

            Assert.AreEqual(result.Count(), 1);
        }

        [TestMethod]
        public void TestMethod_GetListContentMissingItem()
        {
            Catalog catalog = new Catalog();

            Content book = new Content(ContentType.Book,
                new string[] {"Intro C#", "S.Nakov", 
                    "12763892", "http://www.introprogrammi ng.bg"});

            catalog.Add(book);

            Content movie = new Content(ContentType.Movie,
                new string[] {"Intro movie", "S.Nakov", 
                    "12763892", "http://www.bg.info"});

            catalog.Add(movie);

            Content app = new Content(ContentType.Application,
                new string[] {"Intro movie", "S.Nakov", 
                    "12763892", "http://www.bg.info"});

            catalog.Add(app);

            var result = catalog.GetListContent("Missing item", 10);

            Assert.AreEqual(result.Count(), 0);
        }

        [TestMethod]
        public void TestMethod_GetListContentCheckOrder()
        {
            Catalog catalog = new Catalog();

            Content book = new Content(ContentType.Book,
                new string[] {"Intro movie", "S.fdr", 
                    "12763892", "http://www.introprogramming.bg"});

            catalog.Add(book);

            Content movie = new Content(ContentType.Movie,
                new string[] {"Intro movie", "S.fd", 
                    "12763892", "http://www.bg.info"});

            catalog.Add(movie);

            Content app = new Content(ContentType.Application,
                new string[] {"Intro movie", "Sfdv", 
                    "12763892", "http://www.bg.info"});

            catalog.Add(app);

            Content book1 = new Content(ContentType.Book,
                new string[] {"Intro movie", "dd", 
                    "12763892", "http://www.introprogramming.bg"});

            catalog.Add(book1);

            var result = catalog.GetListContent("Intro movie", 10);

            Assert.AreEqual(result.Count(), 4);

            string[] expected = 
            {
                "Application: Intro movie; Sfdv; 12763892; http://www.bg.info",
                "Book: Intro movie; dd; 12763892; http://www.introprogramming.bg",
                "Book: Intro movie; S.fdr; 12763892; http://www.introprogramming.bg",
                "Movie: Intro movie; S.fd; 12763892; http://www.bg.info"
            };
            string[] actual = new string[]
            {
                result.First().ToString(),
                result.Skip(1).First().ToString(),
                result.Skip(2).First().ToString(),
                result.Skip(3).First().ToString()
            };

            CollectionAssert.AreEqual(expected, actual);
        }
        
        //////////////////////////////////////////

       // [TestMethod]
       // public void TestMethod_GetListUpdateItems()
       // {
       //     Catalog catalog = new Catalog();
       //
       //     Content book = new Content(ContentType.Book,
       //         new string[] {"Intro C#", "S.Nakov", 
       //             "12763892", "http://www.introprogramming.bg"});
       //
       //     catalog.Add(book);
       //
       //     Content movie = new Content(ContentType.Movie,
       //         new string[] {"Intro movie", "S.Nakov", 
       //             "12763892", "http://www.bg.info"});
       //
       //     catalog.Add(movie);
       //
       //     Content app = new Content(ContentType.Application,
       //         new string[] {"Intro movie", "S.Nakov", 
       //             "12763892", "http://www.bg.info"});
       //
       //     catalog.Add(app);
       //
       //     int updatedCount = catalog.UpdateContent("miss" , 'new');
       //     Assert.AreEqual(0 , updatedCount);
       //
       //     int updatedCount = catalog.UpdateContent("http://www.bg.info" , 'http://www.bbbbbbbb.info');
       //     Assert.AreEqual(2, updatedCount);
       //
       //     int updatedCount = catalog.UpdateContent("http://www.bg.info" , 'http://www.bbbbbbbb.info');
       //     Assert.AreEqual(0, updatedCount);
       // }

    }
}

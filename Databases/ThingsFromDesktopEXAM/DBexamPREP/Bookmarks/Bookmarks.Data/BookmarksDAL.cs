using Bookmarks.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


public class BookmarksDAL
{
    public static void AddBookmark(string username, string title, string url, string[] tags, string notes)
    {
        //Console.WriteLine("{0} {1} {2} {3} {4}", username, title, url, string.Join(", ", tags), notes);

        BookmarksEntities context = new BookmarksEntities();

        Bookmark newBookmark = new Bookmark();
        newBookmark.User = CreateOrLoadUser(context, username);
        newBookmark.Title = title;
        newBookmark.URL = url;
        newBookmark.Notes = notes;

        foreach (var tagName in tags)
        {
            Tag tag = CreateOrLoadTag(context, tagName);
            newBookmark.Tags.Add(tag);
        }

        //dopulnitelnite tagotve------------------------
        //string[] titleTags = Regex.Split(title, @"\W+");
        string[] titleTags = Regex.Split(title, @"[,'!\. ;?-]+");
        foreach (var titleTagName in titleTags)
        {
            Tag titleTag = CreateOrLoadTag(context, titleTagName);
            newBookmark.Tags.Add(titleTag);
        }
        //dopulnitelnite tagotve-----------------------

        context.Bookmarks.Add(newBookmark);
        context.SaveChanges();
    }

    private static User CreateOrLoadUser(BookmarksEntities context, string username)
    {
        //BookmarksEntities context = new BookmarksEntities();
        User existingUser =
            (from u in context.Users
             where u.Username.ToLower() == username.ToLower()
             select u).FirstOrDefault();
        if (existingUser != null)
        {
            return existingUser;
        }

        User newUser = new User();
        newUser.Username = username;

        context.Users.Add(newUser);

        return newUser;
    }

    private static Tag CreateOrLoadTag(BookmarksEntities context, string tagName)
    {
        //BookmarksEntities context = new BookmarksEntities();
        Tag existingTag =
            (from t in context.Tags
             where t.Name.ToLower() == tagName.ToLower()
             select t).FirstOrDefault();
        if (existingTag != null)
        {
            return existingTag;
        }

        Tag newTag = new Tag();
        newTag.Name = tagName.ToLower();

        context.Tags.Add(newTag);
        context.SaveChanges();

        return newTag;
    }

    //for task 4 ----------------------------------------------------------------
    public static IList<Bookmark> FindBookmarksByUsernameAndTag(string username, string tag)
    {
        BookmarksEntities context = new BookmarksEntities();
        var bookmarkQuery =
            from b in context.Bookmarks
            select b;

        if (username != null)
        {
            bookmarkQuery =
                from b in context.Bookmarks
                where b.User.Username == username
                select b;
            //bookmarkQuery = bookmarkQuery.Where(b => b.User.Username == username);
        }
        if (tag != null)
        {
            bookmarkQuery = bookmarkQuery.Where(b => b.Tags.Any(t => t.Name == tag));
        }

        bookmarkQuery = bookmarkQuery.OrderBy(b => b.URL);

        //for dummies-------------------------------------------------
        //List<Bookmark> results = new List<Bookmark>();
        //foreach (var b in bookmarkQuery)
        //{
        //    if (b.User.Username == username)
        //    {
        //        bool foundTag = false;
        //        foreach (var t in b.Tags)
        //        {
        //            if (t.Name == tag)
        //            {
        //                foundTag = true;
        //            }
        //        }
        //        if (foundTag)
        //        {
        //            results.Add(b);
        //        }
        //    }
        //}
        return bookmarkQuery.ToList();
    }
    //for task 4 -------------------------------------------------------------------


    //for task 5 -----------------------------------------------------------------

    public static IList<Bookmark> FindBookmarks(
            string username, IList<string> tags, int maxResults)
    {
        BookmarksEntities context = new BookmarksEntities();
        var bookmarksQuery =
            from b in context.Bookmarks.Include("User").Include("Tags")
            select b;
        if (username != null)
        {
            bookmarksQuery = bookmarksQuery.Where(
                b => b.User.Username == username);
        }
        foreach (var tag in tags)
        {
            bookmarksQuery = bookmarksQuery.Where(
                b => b.Tags.Any(t => t.Name == tag));
        }
        bookmarksQuery = bookmarksQuery.OrderBy(b => b.URL);
        bookmarksQuery = bookmarksQuery.Take(maxResults);

        return bookmarksQuery.ToList();
    }
}


/*select *
from Bookmarks b join Bookmarks_tags bt
on b.BookmarkID = bt.BookmarkID
join Tags t on bt.TagID = t.TagID
where b.BookmarkID=8*/


/*
delete from Bookmarks_Tags
delete from Tags
delete from Bookmarks
delete from Users*/
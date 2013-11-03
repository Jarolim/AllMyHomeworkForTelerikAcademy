using BookmarksPrep.Models;
using Error_Handler_Control;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BookmarksPrep
{
    public partial class Contact : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public IQueryable<Bookmark> GridViewBookmarks_GetData()
        {
            BookmarksEntities context = new BookmarksEntities();
            return context.Bookmarks.OrderByDescending(b => b.DateOfCreation);
        }

        // The id parameter name should match the DataKeyNames value set on the control
        public void GridViewBookmarks_DeleteItem(int bookmarkId)
        {
            BookmarksEntities context = new BookmarksEntities();
            Bookmark bookmark = context.Bookmarks.Find(bookmarkId);

            context.Bookmarks.Remove(bookmark);
            context.SaveChanges();
            ErrorSuccessNotifier.AddInfoMessage("Bookmark successfully deleted.");
            this.GridViewBookmarks.PageIndex = 0;
            
        }

        //protected void LinkButtonDeleteBookmark_Command(object sender, CommandEventArgs e)
        //{
        //    int bookmarkId = Convert.ToInt32(e.CommandArgument);

        //    BookmarksEntities context = new BookmarksEntities();

        //    context.Database.ExecuteSqlCommand("DELETE FROM Bookmarks WHERE BookmarkId={0}", bookmarkId);
        //}
    }
}
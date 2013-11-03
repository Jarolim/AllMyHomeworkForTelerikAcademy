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
    public partial class EditBookmark : System.Web.UI.Page
    {

        bool isNewBookmark = false;
        private int bookmarkId;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.bookmarkId = Convert.ToInt32(Request.Params["bookmarkId"]);
            isNewBookmark = (this.bookmarkId == 0);
        }

        protected void LinkButtonSaveBookmark_Click(object sender, EventArgs e)
        {
            using (BookmarksEntities context = new BookmarksEntities())
            {
                Bookmark bookmark;
                if (isNewBookmark)
                {
                    bookmark = new Bookmark();
                    context.Bookmarks.Add(bookmark);
                }
                else
                {
                    bookmark = context.Bookmarks.Find(this.bookmarkId);
                }

                try
                {
                    bookmark.Title = this.TextBoxBookmarkTitle.Text;
                    bookmark.URL = this.TextBoxBookmarkURL.Text;
                    bookmark.DateOfCreation = DateTime.Now;

                    context.SaveChanges();

                    ErrorSuccessNotifier.AddInfoMessage("Bookmark " + (this.isNewBookmark ? "created." : "edited."));

                    ErrorSuccessNotifier.ShowAfterRedirect = true;
                    Response.Redirect("EditBookmarks.aspx", false);


                }
                catch (Exception ex)
                {
                    ErrorSuccessNotifier.AddErrorMessage(ex);
                }
            }
        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            if (!isNewBookmark)
            {
                using (BookmarksEntities context = new BookmarksEntities())
                {
                    Bookmark bookmark = context.Bookmarks.Find(bookmarkId);
                    this.TextBoxBookmarkTitle.Text = bookmark.Title;
                    this.TextBoxBookmarkURL.Text = bookmark.URL;
                }
            }
        }

    }
}
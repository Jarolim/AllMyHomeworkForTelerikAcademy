using BookmarksPrep.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BookmarksPrep
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BookmarksEntities context = new BookmarksEntities();
            var bookmarks = context.Bookmarks.Take(5);
            this.ListViewBookmarks.DataSource = bookmarks.ToList();
            this.DataBind();
        }
    }
}
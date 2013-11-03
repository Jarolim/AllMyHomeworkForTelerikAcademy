using BookmarksPrep.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BookmarksPrep
{
    public partial class About : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public IQueryable<Bookmark> GridViewBookmarks_GetData()
        {
            BookmarksEntities context = new BookmarksEntities();
            return context.Bookmarks.OrderByDescending(b => b.DateOfCreation);
        }
    }
}
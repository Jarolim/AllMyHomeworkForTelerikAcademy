using StichtiteForum.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StichtiteForum
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public IQueryable<StichtiteForum.Models.Post> PostsList_GetData()
        {
            StichtiteForumEntities context = new StichtiteForumEntities();

            var posts = context.Posts;

            return posts.OrderByDescending(x => x.PostDate);
        }

        public IQueryable<StichtiteForum.Models.Category> CategoriesList_GetData()
        {
            StichtiteForumEntities context = new StichtiteForumEntities();

            var categories = context.Categories;

            return categories;
        }
    }
}
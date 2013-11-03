using StichtiteForum.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StichtiteForum
{
    public partial class PostsByCategory : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        // The return type can be changed to IEnumerable, however to support
        // paging and sorting, the following parameters must be added:
        //     int maximumRows
        //     int startRowIndex
        //     out int totalRowCount
        //     string sortByExpression
        public IQueryable<StichtiteForum.Models.Post> PostsList_GetData()
        {
            StichtiteForumEntities context = new StichtiteForumEntities();
            int id = Convert.ToInt32(Request.Params["id"]);
            var posts = context.Posts.Where(x=>x.CategoryId == id);

            return posts;
        }
    }
}
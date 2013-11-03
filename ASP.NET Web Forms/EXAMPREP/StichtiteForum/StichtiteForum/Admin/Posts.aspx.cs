namespace StichtiteForum.Admin
{
    using System;
    using System.Linq;
    using System.Web.UI.WebControls;
    using Error_Handler_Control;
    using StichtiteForum.Models;

    public partial class Posts : System.Web.UI.Page
    {
        private string authorId = null;

        public IQueryable<PostModel> GridViewPosts_GetData()
        {
            var context = new StichtiteForumEntities();

            return from post in context.Posts.Include("AspNetUsers")
                    where post.AuthorId == (this.authorId ?? post.AuthorId)
                    orderby post.PostDate
                    select new PostModel
                    {
                        AuthorId = post.AuthorId,
                        AuthorUsername = post.AspNetUser.UserName,
                        CategoryId = post.CategoryId,
                        Content = post.Content,
                        PostDate = post.PostDate,
                        PostId = post.PostId,
                        Title = post.Title
                    };
        }

        public void GridViewPosts_DeleteItem(int postId)
        {
            using (var context = new StichtiteForumEntities())
            {
                try
                {
                    var post = context.Posts.Find(postId);
                    var comments = post.Comments.ToList();
                    var files = post.Files.ToList();

                    context.Comments.RemoveRange(comments);
                    context.Files.RemoveRange(files);
                    context.Posts.Remove(post);

                    context.SaveChanges();
                    this.GridViewPosts.PageIndex = 0;
                    ErrorSuccessNotifier.AddInfoMessage("Post and all of its comments and files successfully deleted.");
                }
                catch (Exception ex)
                {
                    ErrorSuccessNotifier.AddErrorMessage(ex);
                }
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            string paramAuthorId = Request.Params["authorId"];
            if (paramAuthorId != null)
            {
                this.authorId = paramAuthorId;
            }

            this.GridViewPosts.DataSource = null;
            this.GridViewPosts.DataBind();
        }

        protected void DropDownPageSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedListItemValue = int.Parse(this.DropDownPageSize.SelectedItem.Value);
            this.GridViewPosts.PageSize = selectedListItemValue;
            this.GridViewPosts.PageIndex = 0;
        }

        protected void AdminPostGridView_GetContent(object sender, CommandEventArgs e)
        {
            using (var context = new StichtiteForumEntities())
            {
                int postId = int.Parse(e.CommandArgument.ToString());

                var currentPost = (from post in context.Posts
                                   where post.PostId == postId
                                   select post).FirstOrDefault();

                if (currentPost == null)
                {
                    throw new ArgumentException("Post id not found!");
                }

                this.PostContentHeadline.Visible = true;
                this.PostContentHeadline.InnerText = currentPost.Title;

                this.PostContentLiteral.Visible = true;
                this.PostContentLiteral.Text = Server.HtmlEncode(currentPost.Content);
            }
        }
    }
}
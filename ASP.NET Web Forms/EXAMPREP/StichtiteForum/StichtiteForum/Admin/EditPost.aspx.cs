using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using StichtiteForum.Models;
using System.IO;
using Error_Handler_Control;

namespace StichtiteForum.Admin
{
    public partial class EditPosts : System.Web.UI.Page
    {
        private int GetPostIdFromParameters()
        {
            int id = -1;
            if (Request.Params["postId"] == null)
            {
                Response.Redirect("Posts.aspx");
            }
            else if (!int.TryParse(Request.Params["postId"], out id))
            {
                Response.Redirect("Posts.aspx");
            }

            return id;
        }

        public IQueryable<StichtiteForum.Models.File> FileGridView_GetData()
        {
            var context = new StichtiteForumEntities();
            var currentPostId = GetPostIdFromParameters();

            return from file in context.Files
                   where file.PostId == currentPostId
                   select file;
        }

        public void FileGridView_DeleteItem(int fileId)
        {
            using (var context = new StichtiteForumEntities())
            {
                var currentFile = (from file in context.Files
                                   where file.FileId == fileId
                                   select file).FirstOrDefault();

                if (currentFile == null)
                {
                    throw new ArgumentException("File not found!");
                }
                
                var filePath = currentFile.Path;

                context.Files.Remove(currentFile);
                context.SaveChanges();

                if (System.IO.File.Exists(filePath))
                {
                    try
                    {
                        System.IO.File.Delete(filePath);
                    }
                    catch (Exception ex)
                    {
                        ErrorSuccessNotifier.AddErrorMessage(ex);
                    }
                }
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.FileGridView.DataSource = null;
            this.FileGridView.DataBind();
        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            int id = GetPostIdFromParameters();

            using (StichtiteForumEntities context = new StichtiteForumEntities())
            {
                var postToEdit = (from post in context.Posts
                                  where post.PostId == id
                                  select post).FirstOrDefault();

                if (postToEdit == null)
                {
                    Response.Redirect("Posts.aspx");
                }

                this.TextBoxPostTitle.Text = postToEdit.Title;
                this.TextBoxPostContent.Text = postToEdit.Content;
            }
        }

        protected void ButtonCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("Posts.aspx");
        }

        protected void ButtonSubmitPost_Click(object sender, EventArgs e)
        {
            using (StichtiteForumEntities context = new StichtiteForumEntities())
            {
                int currentId = GetPostIdFromParameters();

                var postToEdit = (from post in context.Posts
                                  where post.PostId == currentId
                                  select post).FirstOrDefault();

                if (postToEdit == null)
                {
                    throw new ArgumentNullException();
                }

                postToEdit.Content = this.TextBoxPostContent.Text;
                postToEdit.Title = this.TextBoxPostTitle.Text;

                context.SaveChanges();
            }

            Response.Redirect("Posts.aspx");
        }

        protected void Delete_Click(object sender, EventArgs e)
        {
            using (StichtiteForumEntities context = new StichtiteForumEntities())
            {
                int currentId = GetPostIdFromParameters();

                var post = (from p in context.Posts
                            where p.PostId == currentId
                            select p).FirstOrDefault();

                if (post == null)
                {
                    throw new ArgumentException("Post not found!");
                }

                var comments = post.Comments.ToList();
                var files = post.Files.ToList();

                context.Comments.RemoveRange(comments);
                context.Files.RemoveRange(files);
                context.Posts.Remove(post);

                context.SaveChanges();
            }

            Response.Redirect("Posts.aspx");
        }

        protected void LinkButtonEditItem_Command(object sender, CommandEventArgs e)
        {
            using (StichtiteForumEntities context = new StichtiteForumEntities())
            {
                int fileId = int.Parse(e.CommandArgument.ToString());

                var currentFile = (from file in context.Files
                                   where file.FileId == fileId
                                   select file).FirstOrDefault();

                if (currentFile == null)
                {
                    throw new ArgumentException("File not found!");
                }

                this.EditFileHeadline.Visible = true;

                this.EditFileIdLiteral.Text = currentFile.FileId.ToString();
                this.EditFileIdLiteral.Visible = true;

                this.EditFileTextbox.Text = currentFile.Path;
                this.EditFileTextbox.Visible = true;

                this.EditFileSubmitButton.Visible = true;
            }
        }

        protected void EditFileSubmitButton_Click(object sender, EventArgs e)
        {
            int fileId = int.Parse(this.EditFileIdLiteral.Text);
            string filePath = this.EditFileTextbox.Text;

            using (StichtiteForumEntities context = new StichtiteForumEntities())
            {
                var currentFile = (from file in context.Files
                                   where file.FileId == fileId
                                   select file).FirstOrDefault();

                if (currentFile == null)
                {
                    throw new ArgumentException("File not found!");
                }

                currentFile.Path = filePath;
                context.SaveChanges();

                this.EditFileHeadline.Visible = false;
                this.EditFileIdLiteral.Visible = false;
                this.EditFileTextbox.Visible = false;
                this.EditFileSubmitButton.Visible = false;
            }
        }
    }
}
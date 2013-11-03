using Error_Handler_Control;
using StichtiteForum.Controls;
using StichtiteForum.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StichtiteForum
{
    using System.IO;

    public partial class Post : System.Web.UI.Page
    {
        private int postId;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.postId = Convert.ToInt32(Request.Params["id"]);
        }

        protected void ButtonInsertComment_Click(object sender, EventArgs e)
        {
            ListView listviewCommentsControl = (ListView)this.FormViewPost.FindControl("ListViewComments");
            listviewCommentsControl.InsertItemPosition = InsertItemPosition.LastItem;
            if (!this.User.Identity.IsAuthenticated)
            {
                Response.Redirect("~/Account/Register.aspx");
            }
        }

        protected void ListViewComments_ItemInserted(object sender, ListViewInsertedEventArgs e)
        {
            ListView listviewCommentsControl = (ListView)this.FormViewPost.FindControl("ListViewComments");
            listviewCommentsControl.InsertItemPosition = InsertItemPosition.None;
        }

        public object FormViewPost_GetItem([QueryString]int id)
        {
            var db = new StichtiteForumEntities();
            var post = db.Posts.Find(id);
            return post;
        }

        public IQueryable<Comment> ListViewComments_GetData()
        {
            var db = new StichtiteForumEntities();
            var post = db.Posts.Include("Comments").FirstOrDefault(p => p.PostId == this.postId);
            if (post.Comments == null)
            {
                return new List<Comment>().AsQueryable();
            }
            return post.Comments.OrderBy(c => c.CommentDate).AsQueryable();
        }

        public Control FindControlRecursive(Control control, string id)
        {
            if (control == null) return null;
            //try to find the control at the current level
            Control ctrl = control.FindControl(id);

            if (ctrl == null)
            {
                //search the children
                foreach (Control child in control.Controls)
                {
                    ctrl = FindControlRecursive(child, id);

                    if (ctrl != null) break;
                }
            }
            return ctrl;
        }

        protected void ButtonEditComment_Command(object sender, CommandEventArgs e)
        {
            var db = new StichtiteForumEntities();
            int commentId = Convert.ToInt32(e.CommandArgument);
            if (!this.User.Identity.IsAuthenticated)
            {
                Response.Redirect("~/Account/Login.aspx");
            }
            else if (!(this.User.Identity.Name == db.Comments.Find(commentId).AspNetUser.UserName))
            {
                ErrorSuccessNotifier.AddInfoMessage("You don't have permission to edit this comment");
                Response.Redirect("Post.aspx?id=" + this.postId);
            }
        }

        public void ListViewComments_UpdateItem(int? CommentId)
        {
            var db = new StichtiteForumEntities();
            StichtiteForum.Models.Comment item = null;
            item = db.Comments.Find(CommentId);
            if (item == null)
            {
                ModelState.AddModelError("", String.Format("Item with id {0} was not found", CommentId));
                return;
            }
            TryUpdateModel(item);
            if (ModelState.IsValid)
            {
                db.SaveChanges();
                ErrorSuccessNotifier.AddSuccessMessage("Comment edited sucessfully");
            }

            var uPanel = (UpdatePanel)FindControlRecursive(this, "UpdatePanelComments");
            uPanel.Update();
        }

        public void ListViewComments_InsertItem()
        {
            var db = new StichtiteForumEntities();
            var user = db.AspNetUsers.FirstOrDefault(u => u.UserName == this.User.Identity.Name);
            var cont = ((TextBox)FindControlRecursive(this, "TextBoxComment")).Text;
            var comment = new Comment
            {
                Content = cont,
                PostId = this.postId,
                AspNetUser = user,
                CommentDate = DateTime.Now
            };
            db.Comments.Add(comment);
            try
            {
                db.SaveChanges();
                ErrorSuccessNotifier.AddSuccessMessage("Commment created successfully");
            }
            catch (Exception ex)
            {
                ErrorSuccessNotifier.AddErrorMessage(ex.Message);
            }

            var uPanel = (UpdatePanel)FindControlRecursive(this, "UpdatePanelComments");
            uPanel.Update();
            //Response.Redirect("~/Post.aspx?id=" + this.postId);
        }

        protected void ButtonEditPost_Command(object sender, CommandEventArgs e)
        {
            var db = new StichtiteForumEntities();
            if (!this.User.Identity.IsAuthenticated)
            {
                Response.Redirect("~/Account/Login.aspx");
            }
            else if (!(this.User.Identity.Name == db.Posts.Find(this.postId).AspNetUser.UserName))
            {
                ErrorSuccessNotifier.AddInfoMessage("You don't have permission to edit this post");
                Response.Redirect("Post.aspx?id=" + this.postId);
            }
            Response.Redirect("EditPost.aspx?id=" + this.postId);
        }

        public void FormViewPost_DeleteItem(int? PostId)
        {
            var db = new StichtiteForumEntities();
            if (!this.User.Identity.IsAuthenticated)
            {
                Response.Redirect("~/Account/Login.aspx");
            }
            else if (!(this.User.Identity.Name == db.Posts.Find(this.postId).AspNetUser.UserName))
            {
                ErrorSuccessNotifier.AddInfoMessage("You don't have permission to delete this post");
                Response.Redirect("Post.aspx?id=" + this.postId);
            }
            var post = db.Posts.Find(this.postId);
            db.Posts.Remove(post);
            db.SaveChanges();
            ErrorSuccessNotifier.AddSuccessMessage("Post successfully deleted");
            Response.Redirect("Default.aspx");
        }

        // The id parameter name should match the DataKeyNames value set on the control
        public void ListViewComments_DeleteItem(int? CommentId)
        {
            var db = new StichtiteForumEntities();
            if (!this.User.Identity.IsAuthenticated)
            {
                Response.Redirect("~/Account/Login.aspx");
            }
            else if (!(this.User.Identity.Name == db.Posts.Find(this.postId).AspNetUser.UserName))
            {
                ErrorSuccessNotifier.AddInfoMessage("You don't have permission to delete this comment");
                Response.Redirect("Post.aspx?id=" + this.postId);
            }

            try
            {
                var comment = db.Comments.Find(CommentId);
                db.Comments.Remove(comment);
                db.SaveChanges();
                ErrorSuccessNotifier.AddSuccessMessage("Comment succesfully deleted");
                Response.Redirect("Post.aspx?id=" + this.postId);
            }
            catch (Exception ex)
            {
                ErrorSuccessNotifier.AddErrorMessage(ex.Message);
            }            
        }

        protected void ButtonRefresh_Click(object sender, EventArgs e)
        {
            var uPanel = (UpdatePanel)FindControlRecursive(this, "UpdatePanelComments");
            uPanel.Update();
        }
    }
}
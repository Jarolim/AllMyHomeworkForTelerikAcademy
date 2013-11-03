namespace StichtiteForum.Admin
{
    using System;
    using Error_Handler_Control;
    using StichtiteForum.Models;

    public partial class EditComment : System.Web.UI.Page
    {
        protected void Page_PreRender(object sender, EventArgs e)
        {
            var commentId = Convert.ToInt32(this.Request.Params["commentId"]);

            using (var context = new StichtiteForumEntities())
            {
                try
                {
                    var comment = context.Comments.Find(commentId);
                    this.LabelCommentPostTitle.Text = comment.Post.Title;
                    this.TextBoxCommentContent.Text = comment.Content;
                }
                catch (Exception ex)
                {
                    ErrorSuccessNotifier.AddErrorMessage(ex);
                }
            }
        }

        protected void ButtonSave_Click(object sender, EventArgs e)
        {
            using (var context = new StichtiteForumEntities())
            {
                var commentId = Convert.ToInt32(this.Request.Params["commentId"]);

                try
                {
                    var comment = context.Comments.Find(commentId);
                    comment.Content = this.TextBoxCommentContent.Text;
                    context.SaveChanges();

                    ErrorSuccessNotifier.AddInfoMessage("Comment successfully edited.");
                    ErrorSuccessNotifier.ShowAfterRedirect = true;
                    this.Response.Redirect("Comments.aspx?postId=" + comment.PostId, false);
                }
                catch (Exception ex)
                {
                    ErrorSuccessNotifier.AddErrorMessage(ex);
                }
            }
        }

        protected void ButtonCancel_Click(object sender, EventArgs e)
        {
            using (var context = new StichtiteForumEntities())
            {
                var commentId = Convert.ToInt32(this.Request.Params["commentId"]);

                try
                {
                    var comment = context.Comments.Find(commentId);
                    this.Response.Redirect("Comments.aspx?postId=" + comment.PostId, false);
                }
                catch (Exception ex)
                {
                    ErrorSuccessNotifier.AddErrorMessage(ex);
                }
            }
        }
    }
}
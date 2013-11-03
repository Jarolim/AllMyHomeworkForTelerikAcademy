namespace StichtiteForum.Admin
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Error_Handler_Control;
    using StichtiteForum.Models;

    public partial class Comments : System.Web.UI.Page
    {
        public IQueryable<CommentModel> GridViewComments_GetComments()
        {
            var postId = Convert.ToInt32(this.Request.Params["postId"]);

            try
            {
                var context = new StichtiteForumEntities();
                var comments =
                    from comment in context.Comments
                    where comment.PostId == postId
                    orderby comment.CommentDate descending
                    select new CommentModel
                    {
                        CommentId = comment.CommentId,
                        CommentDate = comment.CommentDate,
                        AuthorUsername = comment.AspNetUser.UserName,
                        Content = comment.Content,
                        PostId = comment.PostId
                    };

                return comments;
            }
            catch (Exception ex)
            {
                ErrorSuccessNotifier.AddErrorMessage(ex);
            }

            return null;
        }

        public void GridViewComments_DeleteComment(int commentId)
        {
            using (var context = new StichtiteForumEntities())
            {
                try
                {
                    var comment = context.Comments.Find(commentId);
                    context.Comments.Remove(comment);
                    context.SaveChanges();
                    this.GridViewComments.PageIndex = 0;
                    ErrorSuccessNotifier.AddInfoMessage("Comment successfully deleted.");
                }
                catch (Exception ex)
                {
                    ErrorSuccessNotifier.AddErrorMessage(ex);
                }
            }
        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            var postId = Convert.ToInt32(this.Request.Params["postId"]);

            using (var context = new StichtiteForumEntities())
            {
                try
                {
                    this.LabelPostTitle.Text = context.Posts.Find(postId).Title;
                }
                catch (Exception ex)
                {
                    ErrorSuccessNotifier.AddErrorMessage(ex);
                }
            }
        }

        protected void GridViewComments_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            using (var context = new StichtiteForumEntities())
            {
                try
                {
                    int commentId = Convert.ToInt32(this.GridViewComments.SelectedDataKey.Value);
                    var comment = context.Comments.Find(commentId);

                    this.LabelCommentContentTitle.Visible = true;
                    this.LiteralCommentContent.Text = this.Server.HtmlEncode(comment.Content);
                }
                catch (Exception ex)
                {
                    ErrorSuccessNotifier.AddErrorMessage(ex);
                }
            }
        }

        protected void DropDownPageSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedListItemValue = int.Parse(this.DropDownPageSize.SelectedItem.Value);
            this.GridViewComments.PageSize = selectedListItemValue;
            this.GridViewComments.PageIndex = 0;
        }
    }
}
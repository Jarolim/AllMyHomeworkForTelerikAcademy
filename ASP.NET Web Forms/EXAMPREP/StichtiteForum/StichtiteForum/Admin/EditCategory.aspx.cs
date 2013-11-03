namespace StichtiteForum.Admin
{
    using System;
    using Error_Handler_Control;
    using StichtiteForum.Models;

    public partial class EditCategory : System.Web.UI.Page
    {
        protected void Page_PreRender(object sender, EventArgs e)
        {
            var categoryId = Convert.ToInt32(this.Request.Params["categoryId"]);

            using (var context = new StichtiteForumEntities())
            {
                try
                {
                    var category = context.Categories.Find(categoryId);
                    this.TextBoxCategoryTitle.Text = category.Title;
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
                var categoryId = Convert.ToInt32(this.Request.Params["categoryId"]);

                try
                {
                    var category = context.Categories.Find(categoryId);
                    category.Title = this.TextBoxCategoryTitle.Text;
                    context.SaveChanges();

                    ErrorSuccessNotifier.AddInfoMessage("Category successfully edited.");
                    ErrorSuccessNotifier.ShowAfterRedirect = true;
                    this.Response.Redirect("Categories.aspx", false);
                }
                catch (Exception ex)
                {
                    ErrorSuccessNotifier.AddErrorMessage(ex);
                }
            }
        }

        protected void ButtonCancel_Click(object sender, EventArgs e)
        {
            this.Response.Redirect("Categories.aspx");
        }
    }
}
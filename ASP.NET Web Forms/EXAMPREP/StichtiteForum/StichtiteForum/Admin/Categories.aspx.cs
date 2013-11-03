namespace StichtiteForum.Admin
{
    using System;
    using System.Linq;
    using Error_Handler_Control;
    using StichtiteForum.Models;

    public partial class Categories : System.Web.UI.Page
    {
        public IQueryable<Category> GridViewUsers_GetCategories()
        {
            try
            {
                var context = new StichtiteForumEntities();
                var categories =
                    from category in context.Categories
                    orderby category.CategoryId
                    select category;

                return categories;
            }
            catch (Exception ex)
            {
                ErrorSuccessNotifier.AddErrorMessage(ex);
            }

            return null;
        }

        public void GridViewUsers_DeleteCategory(int categoryId)
        {
            using (var context = new StichtiteForumEntities())
            {
                try
                {
                    var category = context.Categories.Find(categoryId);

                    foreach (var post in category.Posts)
                    {
                        context.Comments.RemoveRange(post.Comments);
                    }

                    context.Posts.RemoveRange(category.Posts);
                    context.Categories.Remove(category);

                    context.SaveChanges();

                    this.GridViewCategories.PageIndex = 0;
                    ErrorSuccessNotifier.AddInfoMessage("Category successfully deleted.");
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
            this.GridViewCategories.PageSize = selectedListItemValue;
            this.GridViewCategories.PageIndex = 0;
        }

        protected void ButtonCreate_OnClick(object sender, EventArgs e)
        {
            var category = new Category
            {
                Title = this.TextBoxCategoryTitle.Text
            };

            using (var context = new StichtiteForumEntities())
            {
                try
                {
                    context.Categories.Add(category);
                    context.SaveChanges();
                    ErrorSuccessNotifier.AddSuccessMessage("Category added successfully!");
                    ErrorSuccessNotifier.ShowAfterRedirect = true;
                    this.Response.Redirect("Categories.aspx", false);
                }
                catch (Exception ex)
                {
                    ErrorSuccessNotifier.AddErrorMessage(ex);
                }
            }
        }
    }
}
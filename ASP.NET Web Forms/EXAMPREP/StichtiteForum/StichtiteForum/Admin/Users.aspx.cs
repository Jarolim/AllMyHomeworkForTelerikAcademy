namespace StichtiteForum.Admin
{
    using System;
    using System.Linq;
    using Error_Handler_Control;
    using StichtiteForum.Models;

    public partial class Users : System.Web.UI.Page
    {
        public IQueryable<UserModel> GridViewUsers_GetUsers()
        {
            try
            {
                var context = new StichtiteForumEntities();
                var users =
                    from user in context.AspNetUsers
                    orderby user.UserName
                    select new UserModel()
                    {
                        UserId = user.Id,
                        Username = user.UserName,
                        IsAdmin = user.AspNetRoles.FirstOrDefault(r => r.Name == "admin") != null
                    };

                return users;
            }
            catch (Exception ex)
            {
                ErrorSuccessNotifier.AddErrorMessage(ex);
            }

            return null;
        }

        public void GridViewUsers_BanUser(string userId)
        {
            using (var context = new StichtiteForumEntities())
            {
                try
                {
                    var user = context.AspNetUsers.Find(userId);
                    //user.Banned = true;
                    context.SaveChanges();

                    this.GridViewUsers.PageIndex = 0;
                    ErrorSuccessNotifier.AddInfoMessage("User successfully deleted.");
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
            this.GridViewUsers.PageSize = selectedListItemValue;
            this.GridViewUsers.PageIndex = 0;
        }
    }
}
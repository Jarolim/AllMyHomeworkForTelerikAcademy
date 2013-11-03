using System;
using System.Web.DynamicData;
using System.Web.UI.WebControls;

namespace WebApplication2WebApplication
{
    public partial class Insert : System.Web.UI.Page
    {
        protected MetaTable table;

        protected void Page_Init(object sender, EventArgs e)
        {
            this.table = DynamicDataRouteHandler.GetRequestMetaTable(this.Context);
            this.FormView1.SetMetaTable(this.table, this.table.GetColumnValuesFromRoute(this.Context));
            this.DetailsDataSource.ContextTypeName = this.table.DataContextType.FullName;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.Title = this.table.DisplayName;
        }

        protected void FormView1_ItemCommand(object sender, FormViewCommandEventArgs e)
        {
            if (e.CommandName == DataControlCommands.CancelCommandName)
            {
                this.Response.Redirect(this.table.ListActionPath);
            }
        }

        protected void FormView1_ItemInserted(object sender, FormViewInsertedEventArgs e)
        {
            if (e.Exception == null || e.ExceptionHandled)
            {
                this.Response.Redirect(this.table.ListActionPath);
            }
        }
    }
}

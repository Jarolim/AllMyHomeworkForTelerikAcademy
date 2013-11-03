using System;
using System.Web.DynamicData;
using System.Web.UI.WebControls;

namespace WebApplication2WebApplication
{
    public partial class Details : System.Web.UI.Page
    {
        protected MetaTable table;

        protected void Page_Init(object sender, EventArgs e)
        {
            this.table = DynamicDataRouteHandler.GetRequestMetaTable(this.Context);
            this.FormView1.SetMetaTable(this.table);
            this.DetailsDataSource.ContextTypeName = this.table.DataContextType.FullName;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.Title = this.table.DisplayName;
        }

        protected void FormView1_ItemDeleted(object sender, FormViewDeletedEventArgs e)
        {
            if (e.Exception == null || e.ExceptionHandled)
            {
                this.Response.Redirect(this.table.ListActionPath);
            }
        }
    }
}

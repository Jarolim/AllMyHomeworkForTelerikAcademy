using System;
using System.Collections.Generic;
using System.Web.DynamicData;
using System.Web.Routing;
using System.Web.UI.WebControls;

namespace WebApplication2WebApplication
{
    public partial class List : System.Web.UI.Page
    {
        protected MetaTable table;

        protected void Page_Init(object sender, EventArgs e)
        {
            this.table = DynamicDataRouteHandler.GetRequestMetaTable(this.Context);
            this.GridView1.SetMetaTable(this.table, this.table.GetColumnValuesFromRoute(this.Context));
            this.GridDataSource.ContextTypeName = this.table.DataContextType.FullName;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.Title = this.table.DisplayName;
            if (this.table.IsReadOnly)
            {
                this.GridView1.Columns[0].Visible = false;
                this.InsertHyperLink.Visible = false;
                this.GridView1.EnablePersistedSelection = false;
            }
        }

        protected void Label_PreRender(object sender, EventArgs e)
        {
            Label label = sender as Label;
            if (label == null)
            {
                return;
            }

            DynamicFilter dynamicFilter = label.FindControl("DynamicFilter") as DynamicFilter;
            if (dynamicFilter == null)
            {
                return;
            }

            QueryableFilterUserControl filterUserControl = dynamicFilter.FilterTemplate as QueryableFilterUserControl;
            if (filterUserControl != null && filterUserControl.FilterControl != null)
            {
                label.AssociatedControlID = filterUserControl.FilterControl.GetUniqueIDRelativeTo(label);
            }
        }

        protected override void OnPreRenderComplete(EventArgs e)
        {
            IDictionary<string, object> defaultValues = this.GridView1.GetDefaultValues();
            RouteValueDictionary routeValues = new RouteValueDictionary(defaultValues);
            this.InsertHyperLink.NavigateUrl = this.table.GetActionPath(PageAction.Insert, routeValues);

            base.OnPreRenderComplete(e);
        }

        protected void DynamicFilter_FilterChanged(object sender, EventArgs e)
        {
            this.GridView1.PageIndex = 0;
        }
    }
}

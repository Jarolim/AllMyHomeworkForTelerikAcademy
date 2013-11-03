using System;
using System.Collections.Generic;
using System.Web.DynamicData;
using System.Web.Routing;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication2WebApplication.Employees
{
	public partial class List : Page
	{
		private MetaTable table;

        protected MetaTable Table
        {
            get
            {
                return this.table;
            }
        }

        protected void Page_Init(object sender, EventArgs e)
        {
            this.table = DynamicDataRouteHandler.GetRequestMetaTable(this.Context);
            this.GridView1.SetMetaTable(this.Table, this.Table.GetColumnValuesFromRoute(this.Context));
            this.GridDataSource.ContextTypeName = this.Table.DataContextType.FullName;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.Title = this.Table.DisplayName;
            if (this.Table.IsReadOnly)
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
            this.InsertHyperLink.NavigateUrl = this.Table.GetActionPath(PageAction.Insert, routeValues);
            
            base.OnPreRenderComplete(e);
        }

        protected void DynamicFilter_FilterChanged(object sender, EventArgs e)
        {
            this.GridView1.PageIndex = 0;
        }

		/// <summary>
        /// DynamicDataManager1 control.
        /// </summary>
        /// <remarks>
        /// Auto-generated field.
        /// To modify move field declaration from designer file to code-behind file.
        /// </remarks>
        protected global::System.Web.DynamicData.DynamicDataManager DynamicDataManager1;
        
        /// <summary>
        /// UpdatePanel1 control.
        /// </summary>
        /// <remarks>
        /// Auto-generated field.
        /// To modify move field declaration from designer file to code-behind file.
        /// </remarks>
        protected global::System.Web.UI.UpdatePanel UpdatePanel1;
        
        /// <summary>
        /// ValidationSummary1 control.
        /// </summary>
        /// <remarks>
        /// Auto-generated field.
        /// To modify move field declaration from designer file to code-behind file.
        /// </remarks>
        protected global::System.Web.UI.WebControls.ValidationSummary ValidationSummary1;
        
        /// <summary>
        /// GridViewValidator control.
        /// </summary>
        /// <remarks>
        /// Auto-generated field.
        /// To modify move field declaration from designer file to code-behind file.
        /// </remarks>
        protected global::System.Web.DynamicData.DynamicValidator GridViewValidator;
        
        /// <summary>
        /// FilterRepeater control.
        /// </summary>
        /// <remarks>
        /// Auto-generated field.
        /// To modify move field declaration from designer file to code-behind file.
        /// </remarks>
        protected global::System.Web.DynamicData.QueryableFilterRepeater FilterRepeater;
        
        /// <summary>
        /// GridView1 control.
        /// </summary>
        /// <remarks>
        /// Auto-generated field.
        /// To modify move field declaration from designer file to code-behind file.
        /// </remarks>
        protected global::System.Web.UI.WebControls.GridView GridView1;
        
        /// <summary>
        /// GridDataSource control.
        /// </summary>
        /// <remarks>
        /// Auto-generated field.
        /// To modify move field declaration from designer file to code-behind file.
        /// </remarks>
        protected global::Telerik.OpenAccess.Web.OpenAccessLinqDataSource GridDataSource;
        
        /// <summary>
        /// GridQueryExtender control.
        /// </summary>
        /// <remarks>
        /// Auto-generated field.
        /// To modify move field declaration from designer file to code-behind file.
        /// </remarks>
        protected global::System.Web.UI.WebControls.QueryExtender GridQueryExtender;
        
        /// <summary>
        /// InsertHyperLink control.
        /// </summary>
        /// <remarks>
        /// Auto-generated field.
        /// To modify move field declaration from designer file to code-behind file.
        /// </remarks>
        protected global::System.Web.DynamicData.DynamicHyperLink InsertHyperLink;
	}
}
		

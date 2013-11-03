using System;
using System.Web.DynamicData;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication2WebApplication.Cars
{
    public partial class Details : Page
    {
        private MetaTable table;

        protected MetaTable Table
        {
            get
            {
                return this.table;
            }
        }

		protected void DynamicControl_Init(object sender, EventArgs e)
        {
            DynamicControl dynamicControl = sender as DynamicControl;
            if (dynamicControl != null)
            {
                dynamicControl.Mode = DataBoundControlMode.ReadOnly;
            }
        }

        protected void Page_Init(object sender, EventArgs e)
        {
            this.table = DynamicDataRouteHandler.GetRequestMetaTable(this.Context);
            this.FormView1.SetMetaTable(this.Table);
            this.DetailsDataSource.ContextTypeName = this.Table.DataContextType.FullName;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.Title = this.Table.DisplayName;
        }

        protected void FormView1_ItemDeleted(object sender, FormViewDeletedEventArgs e)
        {
            if (e.Exception == null || e.ExceptionHandled)
            {
                this.Response.Redirect(this.Table.ListActionPath);
            }
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
        /// DetailsViewValidator control.
        /// </summary>
        /// <remarks>
        /// Auto-generated field.
        /// To modify move field declaration from designer file to code-behind file.
        /// </remarks>
        protected global::System.Web.DynamicData.DynamicValidator DetailsViewValidator;
        
        /// <summary>
        /// FormView1 control.
        /// </summary>
        /// <remarks>
        /// Auto-generated field.
        /// To modify move field declaration from designer file to code-behind file.
        /// </remarks>
        protected global::System.Web.UI.WebControls.FormView FormView1;
        
        /// <summary>
        /// DetailsDataSource control.
        /// </summary>
        /// <remarks>
        /// Auto-generated field.
        /// To modify move field declaration from designer file to code-behind file.
        /// </remarks>
        protected global::Telerik.OpenAccess.Web.OpenAccessLinqDataSource DetailsDataSource;
        
        /// <summary>
        /// DetailsQueryExtender control.
        /// </summary>
        /// <remarks>
        /// Auto-generated field.
        /// To modify move field declaration from designer file to code-behind file.
        /// </remarks>
        protected global::System.Web.UI.WebControls.QueryExtender DetailsQueryExtender;
        
        /// <summary>
        /// ListHyperLink control.
        /// </summary>
        /// <remarks>
        /// Auto-generated field.
        /// To modify move field declaration from designer file to code-behind file.
        /// </remarks>
        protected global::System.Web.DynamicData.DynamicHyperLink ListHyperLink;
    }
}

	

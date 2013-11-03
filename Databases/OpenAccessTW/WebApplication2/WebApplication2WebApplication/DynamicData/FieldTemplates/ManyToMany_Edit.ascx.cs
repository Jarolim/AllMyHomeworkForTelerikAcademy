using System;
using System.Collections;
using System.ComponentModel;
using System.Web.DynamicData;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.OpenAccess;
using Telerik.OpenAccess.Web;

namespace WebApplication2WebApplication
{
    public partial class ManyToMany_EditField : System.Web.DynamicData.FieldTemplateUserControl
    {
        public override Control DataControl
        {
            get
            {
                return this.CheckBoxList1;
            }
        }

        public void Page_Load(object sender, EventArgs e)
        {
            // Register for the DataSource's updating event
            OpenAccessLinqDataSource dataSource = this.FindDataSourceControl() as OpenAccessLinqDataSource;
            if (dataSource != null)
            {
                // This field template is used both for Editing and Inserting
                dataSource.Updating += new EventHandler<OpenAccessLinqDataSourceUpdateEventArgs>(this.DataSource_Updating);
                dataSource.Inserting += new EventHandler<OpenAccessLinqDataSourceInsertEventArgs>(this.DataSource_Inserting);
            }
        }

        protected void DataSource_Updating(object sender, OpenAccessLinqDataSourceUpdateEventArgs e)
        {
            this.OnUpdateOrInsert(e.OriginalObject);
        }

        protected void DataSource_Inserting(object sender, OpenAccessLinqDataSourceInsertEventArgs e)
        {
            this.OnUpdateOrInsert(e.NewObject);
        }

        private void OnUpdateOrInsert(object originalObject)
        {
            MetaTable childTable = this.ChildrenColumn.ChildTable;
            IList entityCollection = this.Column.EntityTypeProperty.GetValue(originalObject, null) as IList;
            OpenAccessContext dataContext = OpenAccessContextBase.GetContext(originalObject) as OpenAccessContext;
            foreach (object childEntity in childTable.GetQuery(dataContext))
            {
                bool isCurrentlyInList = entityCollection.Contains(childEntity);
                string pkString = childTable.GetPrimaryKeyString(childEntity);
                ListItem listItem = CheckBoxList1.Items.FindByValue(pkString);
                if (listItem == null)
                {
                    continue;
                }

                if (listItem.Selected)
                {
                    if (!isCurrentlyInList)
                    {
                        entityCollection.Add(childEntity);
                    }
                }
                else
                {
                    if (isCurrentlyInList)
                    {
                        entityCollection.Remove(childEntity);
                    }
                }
            }
        }

        protected void CheckBoxList1_DataBound(object sender, EventArgs e)
        {
            MetaTable childTable = this.ChildrenColumn.ChildTable;

            // Comments assume employee/territory for illustration, but the code is generic

            IList entityList = null;
            OpenAccessContext dataContext = null;
            if (Mode == DataBoundControlMode.Edit)
            {
                object entity = null;
                ICustomTypeDescriptor rowDescriptor = this.Row as ICustomTypeDescriptor;
                if (rowDescriptor != null)
                {
                    // Get the real entity from the wrapper
                    entity = rowDescriptor.GetPropertyOwner(null);
                }
                else
                {
                    entity = this.Row;
                }

                // Get the collection of territories for this employee and make sure it's loaded
                entityList = Column.EntityTypeProperty.GetValue(entity, null) as IList;
                if (entityList == null)
                {
                    throw new InvalidOperationException(String.Format("The ManyToMany template does not support the collection type of the '{0}' column on the '{1}' table.", this.Column.Name, this.Table.Name));
                }

                dataContext = OpenAccessContext.GetContext(entity) as OpenAccessContext;
            }

            // Go through all the territories (not just those for this employee)
            foreach (object childEntity in childTable.GetQuery(dataContext))
            {
                MetaTable actualTable = MetaTable.GetTable(childEntity.GetType());
                // Create a checkbox for it
                ListItem listItem = new ListItem(actualTable.GetDisplayString(childEntity), actualTable.GetPrimaryKeyString(childEntity));

                // Make it selected if the current employee has that territory
                if (Mode == DataBoundControlMode.Edit)
                {
                    listItem.Selected = entityList.Contains(childEntity);
                }

                CheckBoxList1.Items.Add(listItem);
            }
        }
    }
}

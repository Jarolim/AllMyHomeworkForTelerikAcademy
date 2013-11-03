using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StichtiteForum.Controls
{
    public partial class AddEditPostControl : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public string PostTitle
        {
            get
            {
                return this.TextBoxPostTitle.Text;
            }
            set
            {
                this.TextBoxPostContent.Text = value;
            }
        }

        public string PostContent
        {
            get
            {
                return this.TextBoxPostContent.Text;
            }
            set 
            { 
                this.TextBoxPostContent.Text = value; 
            }
        }

        public bool HasFileInUploadControl
        {
            get
            {
                return this.FileUploadControl.HasFile;
            }
        }

        public string UploadControlFileName
        {
            get
            {
                return this.FileUploadControl.FileName;
            }
        }

        public event EventHandler SubmitButtonClick
        {
            add 
            { 
                this.ButtonSubmitPost.Click += value; 
            }
            remove
            {
               this.ButtonSubmitPost.Click -= value; 
            }
        }

        protected void ButtonCancel_Click(object sender, EventArgs e)
        {
            this.TextBoxPostTitle.Text = "";
            this.TextBoxPostContent.Text = "";
            Response.Redirect("~/Default.aspx");
        }

        public void SaveFile(string filename)
        {
            if (FileUploadControl.HasFile)
            {
                FileUploadControl.SaveAs(Server.MapPath("~/Uploaded_Files") + filename);
            }
        }
    }
}
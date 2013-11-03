using StringOccurrencesWeb.StringOccurrencesService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StringOccurrencesWeb
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonCalculate_Click(object sender, EventArgs e)
        {
            StringOccurrencesServiceClient client = new StringOccurrencesServiceClient();
            string source = TextBoxFirstString.Text;
            string target = TextBoxSecondString.Text;

            LabelResult.Text = "Result: " + client.GetOccurrencesAsync(source, target).Result;
        }
    }
}
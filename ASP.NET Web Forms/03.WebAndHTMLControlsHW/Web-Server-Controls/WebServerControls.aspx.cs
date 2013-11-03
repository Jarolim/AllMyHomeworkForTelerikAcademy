using System;

namespace Web_Server_Controls
{
    public partial class WebServerControls : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonSubmit_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            int firstNum = int.Parse(this.TextBoxInput1.Text);
            int secondNum = int.Parse(this.TextBoxInput2.Text);
            this.LabelResult.Text =
                "Random number: <b>" + rnd.Next(firstNum, secondNum) + "</b>.<br/>";
            this.LabelResult.Visible = true;
        }
    }
}

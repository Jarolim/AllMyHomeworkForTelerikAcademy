using System;

namespace Html_Server_Controls
{
    public partial class HtmlServerControls : System.Web.UI.Page
    {
        protected void ButtonSubmit_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            int firstNum = int.Parse(this.TextFieldOne.Value);
            int secondNum = int.Parse(this.TextFieldTwo.Value);
            Response.Write("Random between: <b>" + rnd.Next(firstNum,secondNum) + "</b>");
        }
    }
}
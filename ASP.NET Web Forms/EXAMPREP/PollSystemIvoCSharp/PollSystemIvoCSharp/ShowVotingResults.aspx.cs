using PollSystemIvoCSharp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PollSystemIvoCSharp
{
    public partial class ShowVotingResults : System.Web.UI.Page
    {
        protected void Page_PreRender(object sender, EventArgs e)
        {
            int questionId = Convert.ToInt32(Request.Params["questionId"]);
            using (PollSystemIvoCSharpEntities context = new PollSystemIvoCSharpEntities())
            {
                Question question = context.Questions.Find(questionId);
                this.LiteralQuestion.Text = question.QuestionText;
                this.RepeaterAnswers.DataSource = question.Answers.ToList();
                this.RepeaterAnswers.DataBind();
            }
        }
    }
}
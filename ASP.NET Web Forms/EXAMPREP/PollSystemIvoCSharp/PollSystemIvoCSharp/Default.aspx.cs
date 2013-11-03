using PollSystemIvoCSharp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PollSystemIvoCSharp
{
    public partial class _Default : Page
    {
        protected void Page_PreRender(object sender, EventArgs e)
        {
            using (PollSystemIvoCSharpEntities context = new PollSystemIvoCSharpEntities())
            {
                //var questions = context.Questions.Take(3);
                //this.ListViewPolls.DataSource = questions.ToList();
                var questions = context.Questions.Include("Answers").OrderBy(q => Guid.NewGuid());
                this.ListViewPolls.DataSource = questions.Take(3).ToList();
                this.DataBind();
            }
        }

        protected void Vote_Command(object sender, CommandEventArgs e)
        {
            int answerId = Convert.ToInt32(e.CommandArgument);
            using (PollSystemIvoCSharpEntities context = new PollSystemIvoCSharpEntities())
            {
                Answer answer = context.Answers.Find(answerId);
                answer.Votes++;
                context.SaveChanges();
                Response.Redirect("ShowVotingResults.aspx?questionId=" + answer.QuestionId);
            }
            
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}
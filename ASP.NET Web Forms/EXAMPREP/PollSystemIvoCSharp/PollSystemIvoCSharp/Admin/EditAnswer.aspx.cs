using Error_Handler_Control;
using PollSystemIvoCSharp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PollSystemIvoCSharp.Admin
{
    public partial class EditAnswer : System.Web.UI.Page
    {
        bool isNewAnswer = false;
        private int answerId;
        private int questionId;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.answerId = Convert.ToInt32(Request.Params["answerId"]);
            this.questionId = Convert.ToInt32(Request.Params["questionId"]);
            isNewAnswer = (this.answerId == 0);
        }

        protected void LinkButtonSave_Click(object sender, EventArgs e)
        {
            using (PollSystemIvoCSharpEntities context = new PollSystemIvoCSharpEntities())
            {
                Answer answer;
                if (isNewAnswer)
                {
                    answer = new Answer();
                    answer.QuestionId = questionId;
                    context.Answers.Add(answer);
                }
                else
                {
                    answer = context.Answers.Find(this.answerId);
                }


                try
                {
                    answer.AnswerText = this.TextBoxAnswerText.Text;
                    answer.Votes = int.Parse(this.TextBoxVotes.Text);
                    context.SaveChanges();
                    ErrorSuccessNotifier.AddInfoMessage("Answer " + (this.isNewAnswer ? "created." : "edited."));
                    ErrorSuccessNotifier.ShowAfterRedirect = true;
                    Response.Redirect("EditQuestion?questionId=" + answer.QuestionId, false);
                }
                catch (Exception ex)
                {
                    ErrorSuccessNotifier.AddErrorMessage(ex);
                    return;
                }
            }
        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            if (!isNewAnswer)
            {
                using (PollSystemIvoCSharpEntities context = new PollSystemIvoCSharpEntities())
                {
                    Answer answer = context.Answers.Find(answerId);
                    this.TextBoxAnswerText.Text = answer.AnswerText;
                    this.TextBoxVotes.Text = answer.Votes.ToString();
                }
            }
        }


    }
}
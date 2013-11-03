using PollSystemIvoCSharp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Error_Handler_Control;

namespace PollSystemIvoCSharp
{
    public partial class EditQuestions : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        public IQueryable<Question> GridViewQuestions_GetData()
        {
            PollSystemIvoCSharpEntities context = new PollSystemIvoCSharpEntities();
            return context.Questions.OrderBy(q => q.QuestionId);
        }

        // The id parameter name should match the DataKeyNames value set on the control
        public void GridViewQuestions_DeleteItem(int questionId)
        {
            PollSystemIvoCSharpEntities context = new PollSystemIvoCSharpEntities();
            Question question = context.Questions.Include("Answers").FirstOrDefault(q => q.QuestionId == questionId);
            if (question == null)
            {
                ErrorSuccessNotifier.AddErrorMessage("Can not delete question: " + questionId);
            }

            try
            {                 
                context.Answers.RemoveRange(question.Answers);
                context.Questions.Remove(question);
                context.SaveChanges();
                this.GridViewQuestions.PageIndex = 0;
                ErrorSuccessNotifier.AddInfoMessage("Question successfully deleted.");
            }
            catch (Exception ex)
            {
                ErrorSuccessNotifier.AddErrorMessage(ex);
            }

        }
    }
}
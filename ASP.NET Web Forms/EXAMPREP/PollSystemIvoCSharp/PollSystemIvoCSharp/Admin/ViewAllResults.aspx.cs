using PollSystemIvoCSharp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PollSystemIvoCSharp
{
    public partial class ViewAllResults : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //using (PollSystemIvoCSharpEntities context = new PollSystemIvoCSharpEntities())
            //{
            //    var questions = context.Questions.ToList();
            //    this.GridViewQuestions.DataSource = questions;
            //    this.DataBind();
            //}

            //Za iztriwane na cuknatoto
            this.RepeaterAnswers.DataSource = null;
            this.RepeaterAnswers.DataBind();
        }

        protected void GridViewQuestions_SelectedIndexChanged(object sender, EventArgs e)
        {
            int questionId = Convert.ToInt32(this.GridViewQuestions.SelectedDataKey.Value);

            using (PollSystemIvoCSharpEntities context = new PollSystemIvoCSharpEntities())
            {
                var answers = context.Answers.Where(a => a.QuestionId == questionId).ToList();

                this.RepeaterAnswers.DataSource = answers;
                this.RepeaterAnswers.DataBind();
            }
        }

        //protected void GridViewQuestions_PageIndexChanging(object sender, GridViewPageEventArgs e)
        //{
        //    this.GridViewQuestions.PageIndex = e.NewPageIndex;
        //}

        // The return type can be changed to IEnumerable, however to support
        // paging and sorting, the following parameters must be added:
        //     int maximumRows
        //     int startRowIndex
        //     out int totalRowCount
        //     string sortByExpression
        public IQueryable<Question> GridViewQuestions_GetData()
        {
            PollSystemIvoCSharpEntities context = new PollSystemIvoCSharpEntities();
            return context.Questions.OrderBy(q => q.QuestionId);
        }
    }
}
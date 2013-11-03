using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebChat.Models;

namespace WebChat
{
    public partial class Contact : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //this.ListViewMessages.DataSource = null;
            //this.ListViewMessages.DataBind();
        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            //this.ListViewMessages.DataSource = null;
            //this.ListViewMessages.DataBind(); 
            //using (WebChatEntities context = new WebChatEntities())
            //{
            //    var channels = context.Channels.OrderBy(c => c.ChannelId);
            //    this.ListViewChat.DataSource = channels.Take(6).ToList();
            //    this.DataBind();
            //}

            //Response.Redirect("ShowChannels.aspx?channelId=" + channelId);


        }

        // The return type can be changed to IEnumerable, however to support
        // paging and sorting, the following parameters must be added:
        //     int maximumRows
        //     int startRowIndex
        //     out int totalRowCount
        //     string sortByExpression
        public IQueryable GridViewChannels_GetData()
        {
            WebChatEntities context = new WebChatEntities();
            return context.Channels.OrderBy(c => c.ChannelId);
        }

        protected void GridViewChannels_SelectedIndexChanged(object sender, EventArgs e)
        {
            int channelId = Convert.ToInt32(this.GridViewChannels.SelectedDataKey.Value);

            using (WebChatEntities context = new WebChatEntities())
            {
                var messages = context.Messages.Where(
                    m => m.ChannelId == channelId).ToList();
                ListViewMessages.Visible = true;
                ListViewMessages_GetData();
                
                //this.ListViewMessages.DataSource = messages;
                //this.ListViewMessages.DataBind();
                //Response.Redirect("ShowChannels.aspx?channelId=" + channelId);
            }
        }

        // The return type can be changed to IEnumerable, however to support
        // paging and sorting, the following parameters must be added:
        //     int maximumRows
        //     int startRowIndex
        //     out int totalRowCount
        //     string sortByExpression
        public IQueryable<WebChat.Models.Message> ListViewMessages_GetData()
        {
            WebChatEntities context = new WebChatEntities();
            return context.Messages.OrderBy(m => m.MessageId);
        }
    }
}
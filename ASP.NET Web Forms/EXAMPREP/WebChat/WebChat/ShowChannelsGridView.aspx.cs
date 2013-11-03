using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebChat.Models;

namespace WebChat
{
    public partial class About : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {


        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            //using (WebChatEntities context = new WebChatEntities())
            //{
            //    int channelId = Convert.ToInt32(this.GridViewChannels.SelectedDataKey.Value);
            //    var messages = context.Messages.Where(
            //        m => m.ChannelId == channelId).ToList();

            //    this.GridViewMessages.DataSource = messages;
            //    this.GridViewMessages.DataBind();
            //}

            //using (WebChatEntities context = new WebChatEntities())
            //{
            //    var channels = context.Channels.OrderBy(c => c.ChannelId);
            //    this.ListViewChat.DataSource = channels.Take(6).ToList();
            //    this.DataBind();
            //}
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


        protected void GridViewMessages_SelectedIndexChanged(object sender, EventArgs e)
        {

            int channelId = Convert.ToInt32(this.GridViewChannels.SelectedDataKey.Value);

            using (WebChatEntities context = new WebChatEntities())
            {
                var messages = context.Messages.Where(
                    m => m.ChannelId == channelId).ToList();

                this.GridViewMessages.DataSource = messages;
                this.GridViewMessages.DataBind();
            }
        }


        public IQueryable GridViewMessages_GetData()
        {
            WebChatEntities context = new WebChatEntities();
            return context.Messages.OrderBy(m => m.MessageId);
        }

        protected void GridViewChannels_SelectedIndexChanged(object sender, EventArgs e)
        {
            //using (WebChatEntities context = new WebChatEntities())
            //{
            //    this.GridViewMessages.Visible = true;
            //}

            //int channelId = Convert.ToInt32(this.GridViewChannels.SelectedDataKey.Value);

            //using (WebChatEntities context = new WebChatEntities())
            //{
            //    var messages = context.Messages.Where(
            //        m => m.ChannelId == channelId).ToList();

            //    this.GridViewMessages.DataSource = messages;
            //    this.GridViewMessages.DataBind();
            //    this.GridViewMessages.Visible = true;
            //}
        }


    }
}
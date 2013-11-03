using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebChat.Models;

namespace WebChat
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            using(WebChatEntities context = new WebChatEntities())
            {
                var channels = context.Channels.Include("Messages").OrderBy(c => c.ChannelName);
                this.ListViewChat.DataSource = channels.Take(6).ToList();
                this.DataBind();
            }
        }
    }
}
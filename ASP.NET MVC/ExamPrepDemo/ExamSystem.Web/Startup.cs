using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ExamSystem.Web.Startup))]
namespace ExamSystem.Web
{
    public partial class Startup 
    {
        public void Configuration(IAppBuilder app) 
        {
            ConfigureAuth(app);
        }
    }
}

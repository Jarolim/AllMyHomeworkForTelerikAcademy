using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(_02.InformationalApplication.Startup))]
namespace _02.InformationalApplication
{
    public partial class Startup 
    {
        public void Configuration(IAppBuilder app) 
        {
            ConfigureAuth(app);
        }
    }
}

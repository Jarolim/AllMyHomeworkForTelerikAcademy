using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(StichtiteForum.Startup))]
namespace StichtiteForum
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}

using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PollSystemIvoCSharp.Startup))]
namespace PollSystemIvoCSharp
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}

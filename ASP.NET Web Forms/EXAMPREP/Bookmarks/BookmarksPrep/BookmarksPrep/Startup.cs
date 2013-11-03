using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BookmarksPrep.Startup))]
namespace BookmarksPrep
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}

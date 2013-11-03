using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(_01.Calculator.Startup))]
namespace _01.Calculator
{
    public partial class Startup 
    {
        public void Configuration(IAppBuilder app) 
        {
            ConfigureAuth(app);
        }
    }
}

using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RestartMVC.Startup))]
namespace RestartMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CrossSideScripting.Startup))]
namespace CrossSideScripting
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

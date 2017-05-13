using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CrossSidesScripting.Startup))]
namespace CrossSidesScripting
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

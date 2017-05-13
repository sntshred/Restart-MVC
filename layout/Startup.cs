using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(layout.Startup))]
namespace layout
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

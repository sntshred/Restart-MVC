using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(StringLent.Startup))]
namespace StringLent
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

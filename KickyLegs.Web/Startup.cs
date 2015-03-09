using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(KickyLegs.Web.Startup))]
namespace KickyLegs.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

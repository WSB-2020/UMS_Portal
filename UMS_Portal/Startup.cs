using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(UMS_Portal.Startup))]
namespace UMS_Portal
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

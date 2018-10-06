using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SecureWebsitePractices2.Startup))]
namespace SecureWebsitePractices2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

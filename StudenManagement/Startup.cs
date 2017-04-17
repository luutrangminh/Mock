using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(StudenManagement.Startup))]
namespace StudenManagement
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

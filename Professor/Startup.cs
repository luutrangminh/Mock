using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Professor.Startup))]
namespace Professor
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

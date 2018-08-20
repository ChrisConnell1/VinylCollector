using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(VinylCollector.Startup))]
namespace VinylCollector
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

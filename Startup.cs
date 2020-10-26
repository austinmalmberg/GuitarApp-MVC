using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GuitarApp.Startup))]
namespace GuitarApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

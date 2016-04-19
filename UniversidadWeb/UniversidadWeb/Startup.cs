using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(UniversidadWeb.Startup))]
namespace UniversidadWeb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

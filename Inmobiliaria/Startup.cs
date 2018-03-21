using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Inmobiliaria.Startup))]
namespace Inmobiliaria
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

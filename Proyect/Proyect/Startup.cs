using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Proyect.Startup))]
namespace Proyect
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

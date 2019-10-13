using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Carrents_web.Startup))]
namespace Carrents_web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

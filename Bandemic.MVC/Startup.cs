using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Bandemic.MVC.Startup))]
namespace Bandemic.MVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

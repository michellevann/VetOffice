using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(VetOffice.WebMVC.Startup))]
namespace VetOffice.WebMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

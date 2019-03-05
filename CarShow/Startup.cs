using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CarShow.Startup))]
namespace CarShow
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

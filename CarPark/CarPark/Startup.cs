using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CarPark.Startup))]
namespace CarPark
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

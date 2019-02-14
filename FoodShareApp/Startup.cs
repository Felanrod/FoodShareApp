using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FoodShareApp.Startup))]
namespace FoodShareApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CoffeeMachine.Startup))]
namespace CoffeeMachine
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

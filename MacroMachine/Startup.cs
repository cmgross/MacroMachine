using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MacroMachine.Startup))]
namespace MacroMachine
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

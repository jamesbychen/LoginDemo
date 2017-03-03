using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Login_Demostration2.Startup))]
namespace Login_Demostration2
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}

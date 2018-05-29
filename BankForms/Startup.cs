using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BankForms.Startup))]
namespace BankForms
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}

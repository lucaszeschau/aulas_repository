using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ProjetoLoja.Startup))]
namespace ProjetoLoja
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}

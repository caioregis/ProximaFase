using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(ProximaFase.Startup))]
namespace ProximaFase
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
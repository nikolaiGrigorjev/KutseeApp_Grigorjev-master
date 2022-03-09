using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(KutseeApp_Grigorjev.Startup))]
namespace KutseeApp_Grigorjev
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

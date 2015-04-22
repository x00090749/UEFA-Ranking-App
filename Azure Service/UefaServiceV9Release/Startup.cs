using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(UefaServiceV9.Startup))]
namespace UefaServiceV9
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

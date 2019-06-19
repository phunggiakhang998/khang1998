using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DACS.Startup))]
namespace DACS
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Butchers.Startup))]
namespace Butchers
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

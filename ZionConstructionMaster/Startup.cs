using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ZionConstructionMaster.Startup))]
namespace ZionConstructionMaster
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

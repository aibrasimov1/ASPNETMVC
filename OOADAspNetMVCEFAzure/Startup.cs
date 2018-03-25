using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(OOADAspNetMVCEFAzure.Startup))]
namespace OOADAspNetMVCEFAzure
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

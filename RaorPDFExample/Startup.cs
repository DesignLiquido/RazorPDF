using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RaorPDFExample.Startup))]
namespace RaorPDFExample
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

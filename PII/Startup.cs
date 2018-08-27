using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PII.Startup))]
namespace PII
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

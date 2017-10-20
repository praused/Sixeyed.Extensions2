using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Sixeyed.Extensions.Advanced.Web.Startup))]
namespace Sixeyed.Extensions.Advanced.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

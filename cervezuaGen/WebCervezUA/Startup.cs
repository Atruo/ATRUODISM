using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebCervezUA.Startup))]
namespace WebCervezUA
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CervezUAWeb.Startup))]
namespace CervezUAWeb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

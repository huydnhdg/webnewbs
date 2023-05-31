using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebNewsBs.Startup))]
namespace WebNewsBs
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

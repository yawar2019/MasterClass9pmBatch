using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HandleErrorExample.Startup))]
namespace HandleErrorExample
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

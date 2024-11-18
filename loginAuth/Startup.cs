using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(loginAuth.Startup))]
namespace loginAuth
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(UFX_WCCI.Startup))]
namespace UFX_WCCI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

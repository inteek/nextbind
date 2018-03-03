using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(InteekServices.Startup))]
namespace InteekServices
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

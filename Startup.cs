using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MvcProject_Lema.Startup))]
namespace MvcProject_Lema
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FitnessProject.Web.Mvc.App_Start.Startup))]
namespace FitnessProject.Web.Mvc.App_Start
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

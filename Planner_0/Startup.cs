using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Planner_0.Startup))]
namespace Planner_0
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

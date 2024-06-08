using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PassionProjectN01649276.Startup))]
namespace PassionProjectN01649276
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

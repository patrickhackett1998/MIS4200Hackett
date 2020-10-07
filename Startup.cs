using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MIS4200Hackett.Startup))]
namespace MIS4200Hackett
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

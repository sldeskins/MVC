using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MyExample.Startup))]
namespace MyExample
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

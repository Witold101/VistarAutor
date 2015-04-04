using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(VistarAutor.Startup))]
namespace VistarAutor
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

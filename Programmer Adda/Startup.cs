using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Programmer_Adda.Startup))]
namespace Programmer_Adda
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

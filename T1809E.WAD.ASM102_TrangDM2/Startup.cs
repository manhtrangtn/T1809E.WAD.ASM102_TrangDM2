using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(T1809E.WAD.ASM102_TrangDM2.Startup))]
namespace T1809E.WAD.ASM102_TrangDM2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

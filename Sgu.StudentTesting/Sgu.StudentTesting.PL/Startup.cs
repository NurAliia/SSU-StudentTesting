using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Sgu.StudentTesting.PL.Startup))]
namespace Sgu.StudentTesting.PL
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

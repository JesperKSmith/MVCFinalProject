using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FinalExamProject.Startup))]
namespace FinalExamProject
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

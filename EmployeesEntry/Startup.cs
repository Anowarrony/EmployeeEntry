using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EmployeesEntry.Startup))]
namespace EmployeesEntry
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

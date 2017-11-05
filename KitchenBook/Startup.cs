using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(KitchenBook.Startup))]
namespace KitchenBook
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

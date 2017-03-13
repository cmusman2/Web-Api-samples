using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BookaHotel.Startup))]
namespace BookaHotel
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

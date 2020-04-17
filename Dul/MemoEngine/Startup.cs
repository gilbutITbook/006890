using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MemoEngine.Startup))]
namespace MemoEngine
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}

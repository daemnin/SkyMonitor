using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Ninject.Web.Common.OwinHost;
using Ninject.Web.WebApi.OwinHost;
using Owin;
using System.Web.Http;

[assembly: OwinStartup(typeof(SkyMonitor.API.Startup))]

namespace SkyMonitor.API
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var config = new HttpConfiguration();

            //Dependency Injection
            app.UseNinjectMiddleware(NinjectConfig.Configure);

            //CORS
            app.UseCors(CorsOptions.AllowAll);

            //API
            WebApiConfig.Register(config);
            app.UseNinjectWebApi(config);
        }
    }
}

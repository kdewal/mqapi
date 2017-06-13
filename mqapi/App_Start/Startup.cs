using mqapi.Providers;
using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using Owin;
using System;
using System.Web.Http;
using DatabaseService.SDK.Client;
using DatabaseService.SDK.Models.Request.Common;
using DatabaseService.SDK.Models.Response.Common;
using DatabaseService.Models.Enums;
using System.Threading.Tasks;
using mqlib;


[assembly: OwinStartup(typeof(mqapi.App_Start.Startup))]
namespace mqapi.App_Start
{
  public class Startup {
    public void Configuration(IAppBuilder app) {
      ConfigureOAuth(app);
      var config = new HttpConfiguration();
      WebApiConfig.Register(config);
      app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);
      app.UseWebApi(config);
      log4net.Config.XmlConfigurator.Configure();
      CreateCommonCache();
    }

    public void ConfigureOAuth(IAppBuilder app) {
      var OAuthServerOptions = new OAuthAuthorizationServerOptions() {
        AllowInsecureHttp = true,
        TokenEndpointPath = new PathString("/api/token"),
        AccessTokenExpireTimeSpan = TimeSpan.FromDays(1),
        Provider = new SimpleAuthorizationServerProvider(),
        RefreshTokenProvider = new SimpleRefreshTokenProvider()
      };

      //Token Generation
      app.UseOAuthAuthorizationServer(OAuthServerOptions);
      app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());
    }
    public async Task CreateCommonCache()
    {
        var commonClient = new CommonClient();
        var response = await commonClient.GetFullEntityType(new FullEntityRequest {});
        if (response.IsSuccess)
        {
            mqCache kC = new mqCache();
            kC.AddToCache(CacheKey.EntityTypeList.ToString(), response.EntityTypeList);
        }
    }
  }
}
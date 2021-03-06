using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.Extensions.DependencyInjection;
using NetCoreKit.Infrastructure.AspNetCore.Extensions;
using NetCoreKit.Infrastructure.AspNetCore.Rest;

namespace NetCoreKit.Infrastructure.AspNetCore.Miniservice.ConfigureServices
{
  public class HttpConfigureService : IBasicConfigureServices
  {
    public int Priority { get; } = 200;

    public void Configure(IServiceCollection services)
    {
      services.AddHttpContextAccessor();
      services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
      services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();
      services.AddSingleton<IUrlHelper>(fac => new UrlHelper(fac.GetService<IActionContextAccessor>().ActionContext));
      services.AddHttpPolly<RestClient>();
    }
  }
}

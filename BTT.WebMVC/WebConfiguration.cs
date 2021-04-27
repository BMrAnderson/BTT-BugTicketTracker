using BTT.WebMVC.Extensions.DependencyInjection.HTTP;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace BTT.WebMVC
{
    public static class WebMVCConfiguration
    {
        public static IServiceCollection ConfigureWebServices(this IServiceCollection services)
            => services.ConfigureApplicationHttpClients()
                       .AddAutoMapper(Assembly.GetExecutingAssembly());
    }
}

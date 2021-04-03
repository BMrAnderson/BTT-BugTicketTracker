using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BTT.WebMVC.Extensions.HTTP
{
    public static class HttpOrganizationClientExtensions
    {
        private const string apiBaseAddress = "https://localhost:44311/api/organizations"; 

        public static IHttpClientBuilder AddHttpOrganizationClient(this IServiceCollection services)
            => services.AddHttpClient("organization", o => o.BaseAddress = new Uri(apiBaseAddress));
    }
}

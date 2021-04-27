using BTT.WebMVC.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BTT.WebMVC.Extensions.DependencyInjection.HTTP
{
    public static class HttpOrganizationExtensions
    {
        private const string apiBaseAddress = "https://localhost:44311/api/organizations"; 

        public static IHttpClientBuilder AddHttpOrganizationClient(this IServiceCollection services)
            => services.AddHttpClient<IOrganizationHttpService, OrganizationHttpService>(client => client.BaseAddress = new Uri(apiBaseAddress));
    }
}

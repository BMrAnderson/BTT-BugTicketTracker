using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BTT.WebMVC.Extensions.HTTP
{
    public static class HttpProjectClientExtensions
    {
        private const string apiBaseAddress = "https://localhost:44311/api/projects";

        public static IHttpClientBuilder AddHttpProjectClient(this IServiceCollection services)
            => services.AddHttpClient("project", p => p.BaseAddress = new Uri(apiBaseAddress));
    }
}

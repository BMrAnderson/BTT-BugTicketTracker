using BTT.WebMVC.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BTT.WebMVC.Extensions.DependencyInjection.HTTP
{
    public static class HttpProjectExtensions
    {
        private const string apiBaseAddress = "https://localhost:44311/api/projects";

        public static IHttpClientBuilder AddHttpProjectClient(this IServiceCollection services)
            => services.AddHttpClient<IProjectHttpService, ProjectHttpService>(client => client.BaseAddress = new Uri(apiBaseAddress));
    }
}

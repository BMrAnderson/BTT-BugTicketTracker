using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BTT.WebMVC.Extensions.HTTP
{
    public static class HttpIssueClientExtensions
    {
        private const string apiBaseAddress = "https://localhost:44311/api/issues";

        public static IHttpClientBuilder AddHttpIssueClient(this IServiceCollection services)
            => services.AddHttpClient("issue", i => i.BaseAddress = new Uri(apiBaseAddress));
              
    }
}

using BTT.WebMVC.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BTT.WebMVC.Extensions.DependencyInjection.HTTP
{
    public static class HttpIssueExtensions
    {
        private const string apiBaseAddress = "https://localhost:44311/api/issues";

        public static IHttpClientBuilder AddHttpIssueClient(this IServiceCollection services)
            => services.AddHttpClient<IIssueHttpService, IssueHttpService>(client => client.BaseAddress = new Uri(apiBaseAddress));
              
    }
}

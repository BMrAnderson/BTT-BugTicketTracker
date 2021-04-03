using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BTT.WebMVC.Extensions.HTTP
{
    public static class HttpMemberClientExtensions
    {
        private const string apiBaseAddress = "https://localhost:44311/api/members";

        public static IHttpClientBuilder AddHttpMemberClient(this IServiceCollection services)
            => services.AddHttpClient("name", i => i.BaseAddress = new Uri(apiBaseAddress));
    }
}

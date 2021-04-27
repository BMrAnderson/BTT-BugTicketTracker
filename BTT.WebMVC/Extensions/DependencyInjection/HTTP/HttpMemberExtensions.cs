using BTT.WebMVC.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BTT.WebMVC.Extensions.DependencyInjection.HTTP
{
    public static class HttpMemberExtensions
    {
        private const string apiBaseAddress = "https://localhost:44311/api/members";

        public static IHttpClientBuilder AddHttpMemberClient(this IServiceCollection services)
            => services.AddHttpClient<IMemberHttpService, MemberHttpService>(client => client.BaseAddress = new Uri(apiBaseAddress));
    }
}

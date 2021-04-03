using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BTT.WebMVC.Extensions.HTTP
{
    public static class ApplicationHttpClientFactoryExtensions
    {
        public static IServiceCollection RegisterApplicationHttpClients(this IServiceCollection services)
        {
            services.AddHttpIssueClient();
            services.AddHttpMemberClient();
            services.AddHttpOrganizationClient();
            services.AddHttpProjectClient();

            return services;
        }
    }
}

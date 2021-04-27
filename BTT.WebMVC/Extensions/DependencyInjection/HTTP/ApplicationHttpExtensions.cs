using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BTT.WebMVC.Extensions.DependencyInjection.HTTP
{
    public static class ApplicationHttpExtensions
    {
        public static IServiceCollection ConfigureApplicationHttpClients(this IServiceCollection services)
        {
            services.AddHttpIssueClient();
            services.AddHttpMemberClient();
            services.AddHttpOrganizationClient();
            services.AddHttpProjectClient();

            return services;
        }
    }
}

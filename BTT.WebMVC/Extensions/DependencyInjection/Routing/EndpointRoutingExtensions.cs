using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BTT.WebMVC.Extensions.DependencyInjection.Routing;

namespace BTT.WebMVC.Extenstions.DependencyInjection.Routing
{
    public static class EndpointRoutingExtensions
    {
        public static IApplicationBuilder ConfigureWebEndpointRouting(this IApplicationBuilder builder)
            => builder.AddRoutingForDashboardPages()
                      .AddRoutingForAccountPages()
                      .AddRoutingForIssuePages()
                      .AddRoutingForProjectPages();
    }
}

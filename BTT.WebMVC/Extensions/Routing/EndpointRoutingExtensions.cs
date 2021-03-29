using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BTT.WebMVC.Extensions.Routing;

namespace BTT.WebMVC.Extenstions.Routing
{
    public static class EndpointRoutingExtensions
    {
        public static IApplicationBuilder ConfigureApplicationEndpointRouting(this IApplicationBuilder builder)
            => builder.AddRoutingForDashboardPages()
                      .AddRoutingForAccountPages()
                      .AddRoutingForIssuePages()
                      .AddRoutingForProjectPages();
    }
}

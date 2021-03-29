using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BTT.WebMVC.Extensions.Routing
{
    public static class IssuePagesRoutingExtensions
    {
        public static IApplicationBuilder AddRoutingForIssuePages(this IApplicationBuilder builder)
        {
            builder.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "IssueIndexPage",
                    pattern: "{controller=Issue}/{action=Index}/{id?}");
            });

            //Add new endpoints here

            return builder;
        }
    }
}

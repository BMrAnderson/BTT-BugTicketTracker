using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BTT.WebMVC.Extensions.Routing
{
    public static class ProjectPagesRoutingExtensions
    {
        public static IApplicationBuilder AddRoutingForProjectPages(this IApplicationBuilder builder)
        {
            builder.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "ProjectIndexPage",
                    pattern: "{controller=Project}/{action=Index}/{id?}");
            });
            //Add new endpoints here

            return builder;
        }
    }
}

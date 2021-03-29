using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BTT.WebMVC.Extensions.Routing
{
    public static class DashboardPagesRoutingExtensions
    {
        public static IApplicationBuilder AddRoutingForDashboardPages(this IApplicationBuilder builder)
        {
            builder.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Dashboard}/{action=Index}/{id?}");
            });
            //Add new endpoints here

            return builder;
        }
    }
}

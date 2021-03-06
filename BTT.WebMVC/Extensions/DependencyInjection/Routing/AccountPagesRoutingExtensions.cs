using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BTT.WebMVC.Extensions.DependencyInjection.Routing
{
    public static class AccountPagesRoutingExtensions
    {
        public static IApplicationBuilder AddRoutingForAccountPages(this IApplicationBuilder builder)
        {
            builder.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "LoginAccountPage",
                    pattern: "{controller=Account}/{action=LogIn}/{id?}");

                endpoints.MapControllerRoute(
                    name: "RegisterAccountPage",
                    pattern: "{controller=Account}/{action=Register}/{id?}");

                endpoints.MapControllerRoute(
                    name: "DemoAccountPage",
                    pattern: "{controller=Account}/{action=LoginAsDemoAccount}/{id?}");

                endpoints.MapControllerRoute(
                    name: "ProfilePage",
                    pattern: "{controller=Account}/{action=Profile}/{id?}");
            });

            //Add new endpoints here

            return builder;
        }
    }
}

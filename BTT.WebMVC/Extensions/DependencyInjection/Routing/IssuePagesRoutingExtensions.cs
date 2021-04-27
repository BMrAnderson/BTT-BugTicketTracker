using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BTT.WebMVC.Extensions.DependencyInjection.Routing
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

                endpoints.MapControllerRoute(
                    name: "IssueEditPage",
                    pattern: "{controller=Issue}/{action=Edit}/{issueId}");

                endpoints.MapControllerRoute(
                    name: "IssueAttachmentsPage",
                    pattern: "{controller=Issue}/{action=Attachments}/{issueId}");

                endpoints.MapControllerRoute(
                    name: "IssueCommentsPage",
                    pattern: "{controller=Issue}/{action=Comments}/{issueId}");
            });

            //Add new endpoints here

            return builder;
        }
    }
}

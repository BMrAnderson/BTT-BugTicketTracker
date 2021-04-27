using BTT.Application.Services.Issues;
using BTT.Application.Services.Members;
using BTT.Application.Services.Organizations;
using BTT.Application.Services.Projects;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;


namespace BTT.Application
{
    public static class ApplicationConfiguration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
            => services.AddDomainServices()
                       .AddAutoMapper(Assembly.GetExecutingAssembly())
                       .AddMediatR(Assembly.GetExecutingAssembly());

        private static IServiceCollection AddDomainServices(this IServiceCollection services)
        {
            services.AddTransient<IIssueService, IssueService>();
            services.AddTransient<IMemberService, MemberService>();
            services.AddTransient<IProjectService, ProjectService>();
            services.AddTransient<IOrganizationService, OrganizationService>();

            return services;
        }
            //=> services.Scan(scan =>
            //        scan.FromCallingAssembly()
            //            .AddClasses()
            //            .AsMatchingInterface()
            //            .WithTransientLifetime());
    }
}

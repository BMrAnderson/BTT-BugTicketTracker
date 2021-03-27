using BTT.Domain.Common;
using BTT.Domain.Common.Events;
using BTT.Domain.Common.Models;
using BTT.Domain.Common.Repository;
using BTT.Domain.Models.Issues;
using BTT.Domain.Models.Members;
using BTT.Domain.Models.Organizations;
using BTT.Domain.Models.Projects;
using BTT.Infrastructure.Common.Events;
using BTT.Infrastructure.Common.Persistence;
using BTT.Infrastructure.Common.Repositories;
using BTT.Infrastructure.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
namespace BTT.Infrastructure
{
    public static class InfrastructureConfiguration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        => services.AddDatabase(configuration)
                   .AddRepositories();

        private static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
        => services.AddDbContext<IssueTicketTrackerDBContext>(opt =>
                opt.UseSqlServer(configuration.GetConnectionString("BugTrackerDatabase")))
                   .AddTransient<IUnitOfWork, EFUnitOfWork>()
                   .AddTransient<IDomainEventDispatcher, MediatRDomainEventDispatcher>();


        private static IServiceCollection AddRepositories(this IServiceCollection services)
        => services.Scan(scan =>
                scan.FromCallingAssembly()
                    .AddClasses()
                    .AsMatchingInterface()
                    .WithTransientLifetime()); 
    }
}

﻿using BTT.Domain.Models.Issues;
using BTT.Domain.Models.Members;
using BTT.Domain.Models.Organizations;
using BTT.Domain.Models.Projects;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace BTT.Infrastructure.Common.Persistence
{
    public class IssueTicketTrackerDBContext : DbContext
    {
        public IssueTicketTrackerDBContext(DbContextOptions<IssueTicketTrackerDBContext> options) : base(options)
        {
        }

        public DbSet<Issue> Issues { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Organization> Organization { get; set; }
        public DbSet<Member> Member { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
} 
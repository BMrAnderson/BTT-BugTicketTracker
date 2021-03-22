using BTT.Domain.Models.Members;
using BTT.Domain.Models.Organizations;
using BTT.Domain.Models.Projects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTT.Infrastructure.Common.Persistence.Configurations
{
    public class ProjectEntityTypeConfiguration : IEntityTypeConfiguration<Project>
    {
        public void Configure(EntityTypeBuilder<Project> builder)
        {
            builder.ToTable("Projects");

            builder.HasKey(p => p.Id);

            builder.HasMany(p => p.Members);

            builder.Navigation(p => p.Members).Metadata.SetField("_members");

            builder.HasMany(p => p.Issues);

            builder.Navigation(p => p.Issues).Metadata.SetField("_issues");

            builder.HasOne<Organization>().WithMany().HasForeignKey(p => p.OrganizationId);
        }
    }
}

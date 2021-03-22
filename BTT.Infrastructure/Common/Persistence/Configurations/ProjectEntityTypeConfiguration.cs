using BTT.Domain.Models.Organizations;
using BTT.Domain.Models.Projects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BTT.Infrastructure.Common.Persistence.Configurations
{
    public class ProjectEntityTypeConfiguration : IEntityTypeConfiguration<Project>
    {
        public void Configure(EntityTypeBuilder<Project> builder)
        {
            builder.ToTable("Projects");

            builder.HasKey(p => p.Id);

            builder.Navigation(p => p.ProjectMembers).Metadata.SetField("_projectMembers");

            builder.HasMany(p => p.Issues).WithOne(i => i.Project);

            builder.Navigation(p => p.Issues).Metadata.SetField("_issues");

            builder.HasOne<Organization>(p => p.Organization).WithMany(o => o.Projects).HasForeignKey(p => p.OrganizationId);
        }
    }
}
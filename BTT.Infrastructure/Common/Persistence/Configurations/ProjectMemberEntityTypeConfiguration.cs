using BTT.Domain.Models.Projects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BTT.Infrastructure.Common.Persistence.Configurations
{
    public class ProjectMemberEntityTypeConfiguration : IEntityTypeConfiguration<ProjectMember>
    {
        public void Configure(EntityTypeBuilder<ProjectMember> builder)
        {
            builder.HasKey(pm => new { pm.ProjectId, pm.MemberId });

            builder.HasOne(pm => pm.Project).WithMany(p => p.ProjectMembers).HasForeignKey(pm => pm.ProjectId).OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(pm => pm.Member).WithMany(m => m.MemberProjects).HasForeignKey(mp => mp.MemberId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
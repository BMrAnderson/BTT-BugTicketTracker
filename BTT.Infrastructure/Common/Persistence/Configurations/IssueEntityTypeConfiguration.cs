using BTT.Domain.Models.Issues;
using BTT.Domain.Models.Members;
using BTT.Domain.Models.Projects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BTT.Infrastructure.Common.Persistence.Configurations
{
    public class IssueEntityTypeConfiguration : IEntityTypeConfiguration<Issue>
    {
        public void Configure(EntityTypeBuilder<Issue> builder)
        {
            builder.ToTable("Issues");

            builder.HasKey(i => i.Id);

            builder.Property(i => i.Title).HasMaxLength(50).IsRequired();

            builder.Property(i => i.Description).HasMaxLength(200).IsRequired();

            builder.HasOne<Member>(i => i.Member).WithMany(m => m.Issues).HasForeignKey(i => i.MemberId);

            builder.HasOne<Project>(i => i.Project).WithMany(p => p.Issues).HasForeignKey(i => i.ProjectId).OnDelete(DeleteBehavior.Restrict);

            builder.OwnsMany(i => i.Attachments).Property(i => i.FileName).IsRequired();

            builder.Navigation(i => i.Attachments).Metadata.SetField("_attachments");

            builder.OwnsMany(i => i.Comments).Property(c => c.Text).HasMaxLength(100).IsRequired();

            builder.Navigation(i => i.Comments).Metadata.SetField("_comments");
        }
    }
}
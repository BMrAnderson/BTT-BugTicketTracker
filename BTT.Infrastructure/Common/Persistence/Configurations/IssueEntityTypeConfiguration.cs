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

            builder.HasOne<Member>().WithMany().HasForeignKey(m => m.AssignedMemberId);

            builder.HasOne<Project>().WithMany().HasForeignKey(i => i.AssignedProjectId);

            builder.OwnsMany(i => i.Attachments);
            
            builder.Navigation(i => i.Attachments).Metadata.SetField("_attachments");

            builder.OwnsMany(i => i.Comments);
            
            builder.Navigation(i => i.Comments).Metadata.SetField("_comments");
        }
    }
}
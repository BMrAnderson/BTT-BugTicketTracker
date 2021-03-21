using BTT.Domain.Models.Issues;
using BTT.Domain.Models.Members;
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
    public class IssueEntityTypeConfiguration : IEntityTypeConfiguration<Issue>
    {
        public void Configure(EntityTypeBuilder<Issue> builder)
        {
            builder.ToTable("Issues");

            builder.HasKey(i => i.Id);

            builder.HasOne<Member>()
                .WithMany()
                .HasForeignKey(i => i.AssignedMemberId)
                .IsRequired();

            builder.HasOne<Project>()
                .WithMany()
                .HasForeignKey(i => i.AssignedProjectId)
                .IsRequired();

            builder.Property(i => i.Title)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(i => i.Description)
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(i => i.Priority);

            builder.OwnsMany(i => i.Attachments);

            builder.OwnsMany(i => i.Comments);
        }
    }
}

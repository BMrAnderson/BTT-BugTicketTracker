using BTT.Domain.Models.Issues;
using BTT.Domain.Models.Members;
using BTT.Domain.Models.Notifications;
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
    public class MemberEntityTypeConfiguration : IEntityTypeConfiguration<Member>
    {
        public void Configure(EntityTypeBuilder<Member> builder)
        {
            builder.ToTable("Members");

            builder.HasKey(m => m.Id);

            builder.Property(m => m.FirstName)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(m => m.LastName)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(m => m.Email)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(m => m.Password)
                .HasMaxLength(12)
                .IsRequired();

            builder.HasMany<Issue>(m => m.Issues)
                .WithOne()
                .HasForeignKey(i => i.AssignedMemberId);

            builder.HasMany<Project>(m => m.Projects);

            builder.OwnsMany(m => m.Notifications);
        }
    }
}

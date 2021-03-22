using BTT.Domain.Models.Issues;
using BTT.Domain.Models.Members;
using BTT.Domain.Models.Notifications;
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
    public class MemberEntityTypeConfiguration : IEntityTypeConfiguration<Member>
    {
        public void Configure(EntityTypeBuilder<Member> builder)
        {
            builder.ToTable("Members");

            builder.HasKey(m => m.Id);

            builder.Property(m => m.FirstName).HasMaxLength(50).IsRequired();

            builder.Property(m => m.LastName).HasMaxLength(50).IsRequired();

            builder.Property(m => m.Email).HasMaxLength(100).IsRequired();

            builder.Property(m => m.Password).HasMaxLength(12).IsRequired();

            builder.HasOne<Organization>().WithMany().HasForeignKey(m => m.AssignedOrganizationId);

            builder.HasMany(m => m.Issues);

            builder.Navigation(m => m.Issues).Metadata.SetField("_issues");

            builder.HasMany(m => m.Projects);

            builder.Navigation(m => m.Projects).Metadata.SetField("_projects");

            //builder.OwnsMany(m => m.Notifications);

            //builder.Navigation(m => m.Notifications).Metadata.SetField("_notifications");
        }
    }
}

using BTT.Domain.Models.Members;
using BTT.Domain.Models.Organizations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

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

            builder.HasMany(m => m.Issues).WithOne(i => i.Member);

            builder.Navigation(m => m.Issues).Metadata.SetField("_issues");

            builder.Navigation(m => m.MemberProjects).Metadata.SetField("_memberProjects");

            //builder.OwnsMany(m => m.Notifications);

            //builder.Navigation(m => m.Notifications).Metadata.SetField("_notifications");
        }
    }
}
using BTT.Domain.Models.Organizations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BTT.Infrastructure.Common.Persistence.Configurations
{
    public class OrganizationEntityTypeConfiguration : IEntityTypeConfiguration<Organization>
    {
        public void Configure(EntityTypeBuilder<Organization> builder)
        {
            builder.ToTable("Organizations");

            builder.HasKey(o => o.Id);

            builder.Property(o => o.Name).HasMaxLength(50).IsRequired();

            builder.HasMany(o => o.Members).WithOne(m => m.Organization).HasForeignKey(m => m.OrganizationId);

            builder.Navigation(o => o.Members).Metadata.SetField("_members");

            builder.HasMany(o => o.Projects).WithOne(p => p.Organization).HasForeignKey(p => p.OrganizationId);

            builder.Navigation(o => o.Projects).Metadata.SetField("_projects");
        }
    }
}
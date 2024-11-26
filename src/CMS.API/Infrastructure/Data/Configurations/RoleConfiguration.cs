using CMS.API.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CMS.API.Infrastructure.Data.Configurations;

public class RoleConfiguration : IEntityTypeConfiguration<Role>
{
  public void Configure(EntityTypeBuilder<Role> builder)
  {
    builder.ToTable("Roles");
    builder.Property(x=>x.Code).HasMaxLength(50).IsRequired();
    builder.Property(x=>x.Name).HasMaxLength(50).IsRequired();
    builder.HasOne(x => x.Parent).WithMany(x => x.Child).HasForeignKey(x => x.ParentId);
  }
}

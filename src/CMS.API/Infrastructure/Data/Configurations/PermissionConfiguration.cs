using CMS.API.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CMS.API.Infrastructure.Data.Configurations;

public class PermissionConfiguration : IEntityTypeConfiguration<Permission>
{
  public void Configure(EntityTypeBuilder<Permission> builder)
  {
    builder.ToTable("Permissions");
    builder.HasKey(x => new { x.ObjectId, x.ActionClassId });
    builder.HasOne(x => x.ActionClass).WithMany(x => x.Permissions).HasForeignKey(x => x.ActionClassId);
  }
}

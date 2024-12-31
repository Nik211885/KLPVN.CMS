using CMS.API.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CMS.API.Infrastructure.Data.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
  public void Configure(EntityTypeBuilder<User> builder)
  {
    builder.ToTable("Users");
    builder.Property(x=>x.UserName).HasMaxLength(50).IsRequired();
    builder.HasIndex(x=>x.UserName).IsUnique();
    builder.Property(x=>x.PhoneNumber).HasMaxLength(10).IsRequired();
    builder.Property(x=>x.Email).HasMaxLength(100);
    builder.Property(x => x.Address).HasMaxLength(150);
    builder.Property(x=>x.FullName).HasMaxLength(100).IsRequired();
    builder.Property(x=>x.PasswordHash).HasMaxLength(100).IsRequired();
    builder.Property(x=>x.Salt).HasMaxLength(100).IsRequired();
    builder.Property(x => x.Avatar).HasMaxLength(100);
    builder.HasMany(x => x.UserRoles).WithOne(x=>x.User)
      .HasForeignKey(x=>x.UserId);
  }
}

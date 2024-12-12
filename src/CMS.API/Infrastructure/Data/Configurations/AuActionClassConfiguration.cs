using CMS.API.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CMS.API.Infrastructure.Data.Configurations;

public class AuActionClassConfiguration : IEntityTypeConfiguration<AuActionClass>
{
  public void Configure(EntityTypeBuilder<AuActionClass> builder)
  {
    builder.ToTable("AuActionClasses");
    builder.HasKey(x=>x.Id);
    builder.Property(x=>x.Code).HasMaxLength(50).IsRequired();
    builder.Property(x=>x.Name).HasMaxLength(50).IsRequired();
    builder.Property(x=>x.Path).HasMaxLength(75).IsRequired();
    builder.HasOne(x => x.AuClass).WithMany(x => x.AuActionClasses).HasForeignKey(x => x.ClassId);
  }
}

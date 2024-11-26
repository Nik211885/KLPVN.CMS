using CMS.API.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CMS.API.Infrastructure.Data.Configurations;

public class AuActionConfiguration : IEntityTypeConfiguration<AuAction>
{
  public void Configure(EntityTypeBuilder<AuAction> builder)
  {
    builder.ToTable("AuActions");
    builder.HasKey(x => x.Id);
    builder.Property(x=>x.Code).HasMaxLength(50).IsRequired();
    builder.Property(x=>x.Name).HasMaxLength(50).IsRequired();
  }
}

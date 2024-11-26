using CMS.API.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CMS.API.Infrastructure.Data.Configurations;

public class ContentConfiguration : IEntityTypeConfiguration<Content>
{
  public void Configure(EntityTypeBuilder<Content> builder)
  {
    builder.ToTable("Contents");
    builder.HasKey(x => x.Id);
    builder.Property(x=>x.Code).HasMaxLength(50).IsRequired();
    builder.Property(x => x.Title).HasMaxLength(500).IsRequired();
    builder.Property(x=>x.Description).HasMaxLength(500);
    builder.Property(x=>x.Avatar).HasMaxLength(150);
    builder.Property(x => x.Contents).HasColumnType("TEXT").IsRequired();
    builder.Property(x=>x.Comment).HasColumnType("TEXT");
  }
}

using CMS.API.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CMS.API.Infrastructure.Data.Configurations;

public class FeedBackConfiguration: IEntityTypeConfiguration<FeedBack>
{
  public void Configure(EntityTypeBuilder<FeedBack> builder)
  {
    builder.ToTable("FeedBacks");
    builder.Property(x => x.FullName).HasMaxLength(50).IsRequired();
    builder.Property(x => x.Phone).HasMaxLength(10).IsRequired();
    builder.Property(x => x.Title).HasMaxLength(100).IsRequired();
    builder.Property(x => x.Email).HasMaxLength(100);
    builder.Property(x => x.Address).HasMaxLength(100);
    builder.Property(x => x.Note).HasColumnType("TEXT");
    builder.HasKey(x=>x.Id);
  }
}

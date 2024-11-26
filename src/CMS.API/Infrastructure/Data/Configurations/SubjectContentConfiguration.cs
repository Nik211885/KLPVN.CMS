using CMS.API.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CMS.API.Infrastructure.Data.Configurations;

public class SubjectContentConfiguration
  : IEntityTypeConfiguration<SubjectContent>
{
  public void Configure(EntityTypeBuilder<SubjectContent> builder)
  {
    builder.ToTable("SubjectContents");
    builder.HasKey(x => new { x.ContentId, x.SubjectId });
    builder.HasOne(x=>x.Content).WithMany(x=>x.SubjectContents).HasForeignKey(x=>x.ContentId);
    builder.HasOne(x=>x.Subject).WithMany(x=>x.SubjectContents).HasForeignKey(x=>x.SubjectId);
  }
}

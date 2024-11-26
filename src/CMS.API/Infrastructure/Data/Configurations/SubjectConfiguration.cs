using CMS.API.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CMS.API.Infrastructure.Data.Configurations;

public class SubjectConfiguration : IEntityTypeConfiguration<Subject>
{
  public void Configure(EntityTypeBuilder<Subject> builder)
  {
    builder.ToTable("Subjects");
    builder.HasKey(x => x.Id);
    builder.HasOne(x=>x.Parent).WithMany(x=>x.Children).HasForeignKey(x=>x.ParentId);
    builder.Property(x => x.Name).HasMaxLength(75).IsRequired();
    builder.Property(x=>x.Code).HasMaxLength(50).IsRequired();
  }
}

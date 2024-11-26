using CMS.API.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CMS.API.Infrastructure.Data.Configurations;

public class InformationOrganizationConfiguration 
  : IEntityTypeConfiguration<InformationOrganization>
{
  public void Configure(EntityTypeBuilder<InformationOrganization> builder)
  {
    builder.ToTable("InformationOrganizations");
    builder.HasKey(x => x.Id);
    builder.Property(x=>x.Code).HasMaxLength(50).IsRequired();
    builder.Property(x=>x.OrganizationName).HasMaxLength(200).IsRequired();
    builder.Property(x=>x.Address).HasMaxLength(200).IsRequired();
    builder.Property(x=>x.Phone).HasMaxLength(10).IsRequired();
    builder.Property(x => x.Email).HasMaxLength(50);
    builder.Property(x => x.Icon).HasMaxLength(150);
    builder.Property(x=>x.RefFacebook).HasMaxLength(150);
    builder.Property(x=>x.RefYoutube).HasMaxLength(150);
    builder.Property(x=>x.RefX).HasMaxLength(150);
    builder.Property(x=>x.RefSocial).HasMaxLength(150);
    builder.Property(x=>x.RefTikTok).HasMaxLength(150);
  }
}

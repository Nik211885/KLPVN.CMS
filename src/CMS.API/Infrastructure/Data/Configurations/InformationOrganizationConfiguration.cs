using CMS.API.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CMS.API.Infrastructure.Data.Configurations;

public class InformationOrganizationConfiguration 
  : IEntityTypeConfiguration<InformationOrganization>
{
  public void Configure(EntityTypeBuilder<InformationOrganization> builder)
  {
    throw new NotImplementedException();
  }
}

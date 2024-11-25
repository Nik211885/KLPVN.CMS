using CMS.API.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CMS.API.Infrastructure.Data.Configurations;

public class SubjectConfiguration : IEntityTypeConfiguration<Subject>
{
  public void Configure(EntityTypeBuilder<Subject> builder)
  {
    throw new NotImplementedException();
  }
}

using CMS.API.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CMS.API.Infrastructure.Data.Configurations;

public class FeedBackConfiguration: IEntityTypeConfiguration<FeedBack>
{
  public void Configure(EntityTypeBuilder<FeedBack> builder)
  {
    throw new NotImplementedException();
  }
}

using Microsoft.EntityFrameworkCore;

namespace CMS.API.Infrastructure.Data.Seeder;

public static class FeedBack
{
  public static async Task SeedAsync(ApplicationDbContext dbContext)
  {
    var isExitsFeedBack = await dbContext.FeedBacks.AnyAsync();
    if (isExitsFeedBack)
    {
      return;
    }
    List<Entities.FeedBack> feedBacks = [];
    for (int i = 0; i < 1_000; i++)
    {
      feedBacks.Add(new ()
      {
        Id = Guid.NewGuid(),
        Address = Faker.Address.StreetName(),
        Email = Faker.Internet.Email(),
        Note = Faker.Lorem.Paragraph(),
        Phone = Faker.RandomNumber.Next(1000000000,9999999999).ToString(),
        Title = Faker.Company.Name(),
        FullName = Faker.Name.FullName(),
      }); 
    }
    dbContext.FeedBacks.AddRange(feedBacks);
    await dbContext.SaveChangesAsync();
  }
}

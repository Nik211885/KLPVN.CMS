using CMS.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace CMS.API.Infrastructure.Data.Seeder;

public class SubjectSeeder
{
  public static async Task SeedAsync(ApplicationDbContext dbContext)
  {
    if (await dbContext.Subjects.AnyAsync())
    {
      return;
    }
    var subject = new List<Entities.Subject>()
    {
      
    };
    dbContext.AddRange(subject);
    await dbContext.SaveChangesAsync();
  }
}

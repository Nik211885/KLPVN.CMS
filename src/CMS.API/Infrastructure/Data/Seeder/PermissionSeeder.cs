using CMS.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace CMS.API.Infrastructure.Data.Seeder;

public static class PermissionSeeder
{
  public static async Task SeederAsync(ApplicationDbContext dbContext)
  {
    if (await dbContext.UserRoles.AnyAsync())
    {
      return;
    }
    var user = await dbContext.Users.FirstOrDefaultAsync(x=>x.UserName == "admin");
    var role = await dbContext.Roles.FirstOrDefaultAsync(x => x.Code == "Administrator");
    if (user is null || role is null)
    {
      return;
    }
    // just add role for permission
    await dbContext.SaveChangesAsync();
  }
}

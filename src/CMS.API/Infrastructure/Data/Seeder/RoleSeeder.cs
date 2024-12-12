using CMS.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace CMS.API.Infrastructure.Data.Seeder;

public static class RoleSeeder
{
  public static async Task SeederAsync(ApplicationDbContext dbContext)
  {
    if (await dbContext.Roles.AnyAsync())
    {
      return;
    }
    var roles = new List<Role>()
    {
      new()
      {
        Code = "Administrator",
        Name = "Người quản lý hệ thống",
      }
    };
    dbContext.Roles.AddRange(roles);
    await dbContext.SaveChangesAsync();
  }
}

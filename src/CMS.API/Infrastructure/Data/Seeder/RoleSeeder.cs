using CMS.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace CMS.API.Infrastructure.Data.Seeder;

public static class RoleSeeder
{
  public static async Task SeederAsync(ApplicationDbContext dbContext)
  {
    if (await dbContext.Roles.CountAsync() >= 2)
    {
      return;
    }

    var rolesOld = await dbContext.Roles.ToListAsync();
    dbContext.Roles.RemoveRange(rolesOld);
    await dbContext.SaveChangesAsync();
    var roles = new List<Role>()
    {
      new()
      {
        Code = "Administrator",
        Name = "Người quản lý hệ thống",
      },
      new(){
        Code = "Editor",
        Name = "Biên tập tin"
      }
    };
    dbContext.Roles.AddRange(roles);
    await dbContext.SaveChangesAsync();
  }
}

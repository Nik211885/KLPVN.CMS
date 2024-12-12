using KLPVN.Core.Helper;
using Microsoft.EntityFrameworkCore;

namespace CMS.API.Infrastructure.Data.Seeder;

public static class UserSeeder
{
  public static async Task SeederAsync(ApplicationDbContext dbContext)
  {
    if (await dbContext.Users.AnyAsync())
    {
      return;
    }
    
    var role = await dbContext.Roles.FirstOrDefaultAsync(x => x.Code == "Administrator");
    if (role is null)
    {
      return;
    }
    string salt = String.Empty;
    var users = new List<Entities.User>()
    {
      new ()
      {
        UserName = "admin",
        PhoneNumber = "0388080661",
        Email = "khacninh2020@gmail.com",
        Address = "Thanh Hoa",
        FullName = "Le Khac Ninh",
        Salt = (salt = SecurityHelper.GenerateSalt()),
        PasswordHash = SecurityHelper.HashPassword("K@lnt211885",salt),
        Gender = true,
        IsActive = true,
        Avatar = "/avatar",
        UserRoles = [
          new(role.Id),
        ]
      }
    };
    dbContext.AddRange(users);
    await dbContext.SaveChangesAsync();
  }
}

using KLPVN.Core.Helper;
using Microsoft.EntityFrameworkCore;

namespace CMS.API.Infrastructure.Data.Seeder;

public static class UserSeeder
{
  public static async Task SeederAsync(ApplicationDbContext dbContext)
  {
    if (await dbContext.Users.CountAsync() >= 10)
    {
      return;
    }
    var usersOld = await dbContext.Users.ToListAsync();
    dbContext.Users.RemoveRange(usersOld);
    await dbContext.SaveChangesAsync();
    var roleAdmin = await dbContext.Roles.FirstOrDefaultAsync(x => x.Code == "Administrator");
    var roleEditor = await dbContext.Roles.FirstOrDefaultAsync(x => x.Code == "Editor");
    if (roleAdmin is null || roleEditor is null)
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
          new(roleAdmin.Id),
        ]
      }
    };
    for (int i = 0; i < 9; i++)
    {
      users.Add(
        new()
        {
          UserName = Faker.Name.First(),
          PhoneNumber = Faker.RandomNumber.Next(1000000000, 9999999999).ToString(),
          Email = Faker.Internet.Email(),
          Address = Faker.Address.City(),
          FullName = Faker.Name.FullName(),
          Salt = (salt = SecurityHelper.GenerateSalt()),
          PasswordHash = SecurityHelper.HashPassword("K@lnt211885", salt),
          Gender = Faker.RandomNumber.Next(0, 2) == 0,
          IsActive = true,
          UserRoles =
          [
            new(roleEditor.Id),
          ]
        });
    }
    dbContext.AddRange(users);
    await dbContext.SaveChangesAsync();
  }
}

using CMS.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace CMS.API.Infrastructure.Data.Seeder;

public static class InformationOrganizationSeeder
{
  public static async Task SeederAsync(ApplicationDbContext dbContext)
  {
    var count = await dbContext.InformationOrganizations.CountAsync();
    if (count > 0)
    {
      return;
    }
    var informationOrganization = new InformationOrganization()
    {
      Id = Guid.NewGuid(),
      Code = "HiTi",
      Address = "So 175 Phuong Liet Quan Dong Da Thanh Pho Ha Noi",
      CreatedBy = "System",
      Email = "hiti@hotmail.com",
      Icon = "https://icon.icon",
      IsActive = true,
      OrganizationName = "Hi Ti",
      Phone = "0123456789",
      RefX = "https://x.com/hiti",
      RefYoutube = "https://youtube.com/hiti",
      RefFacebook = "https://facebook.com/hiti",
      RefSocial = "https://social.com/hiti",
      RefTikTok = "https://tiktok.com/hiti",
    };
    dbContext.InformationOrganizations.Add(informationOrganization);
    await dbContext.SaveChangesAsync();
  }
}

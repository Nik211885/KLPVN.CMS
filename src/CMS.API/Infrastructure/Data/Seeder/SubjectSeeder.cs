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
      new ()
      {
        Code = "Gt",
        Name = "Giới thiệu",
        DisplayOrder = 1,
        IsActive = true,
      },
      new ()
      {
        Code = "DVTV",
        Name = "Dịch vụ tư vấn",
        DisplayOrder = 2,
        IsActive = true,
        Children =
        [
          new()
          {
            Code = "LearnHr", Name = "Learn Hr", DisplayOrder = 3, IsActive = true,
          },

          new()
          {
            Code = "KNL", Name = "Khung năng lực", DisplayOrder = 4, IsActive = true,
          },

          new()
          {
            Code = "KPIs", Name = "KPIs", DisplayOrder = 5, IsActive = true,
          },

          new()
          {
            Code = "KSVDX", Name = "Khảo sát và đề xuất", DisplayOrder = 6, IsActive = true,
          }

        ],
      },
      new()
      {
        Code = "DVDT",
        Name = "Dịch vụ đào tạo",
        DisplayOrder = 7,
        IsActive = true,
        Children = [
          new()
          {
            Code = "Inhouse",
            Name = "Inhouse",
            DisplayOrder = 8,
            IsActive = true,
            Children = [
              new(){Code = "KHPhi&Cp", Name = "Khách hàng Phi&P", DisplayOrder = 9, IsActive = true},
              new(){Code = "CTDT", Name = "Chương trình đào tạo", DisplayOrder = 10, IsActive = true},
            ]
          },
          new()
          {
            Code = "Public",
            Name = "Public",
            DisplayOrder = 11,
            IsActive = true,
            Children = [
              new(){Code = "CKH", Name = "Các khóa học", DisplayOrder = 12, IsActive = true},
              new(){Code = "LKG", Name = "Lịch khai giảng", DisplayOrder = 13, IsActive = true},
            ]
          },
          
        ]
      },
      new()
      {
        Code = "ELearning",
        Name = "E Learning",
        DisplayOrder = 14,
        IsActive = true,
      },
      new()
      {
        Code = "td",
        Name = "Tuyển dụng",
        DisplayOrder = 15,
        IsActive = true,
      },
      new()
      {
      Code = "cs",
      Name = "Chia sẽ",
      DisplayOrder = 16,
      IsActive = true,
    }
    };
    dbContext.AddRange(subject);
    await dbContext.SaveChangesAsync();
  }
}

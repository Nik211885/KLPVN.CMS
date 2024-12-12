using Microsoft.EntityFrameworkCore;

namespace CMS.API.Infrastructure.Data.Seeder;

public static class AuClassSeeder
{
  public static async Task SeederAsync(ApplicationDbContext dbContext)
  {
    if (await dbContext.AuClasses.AnyAsync())
    {
      return;
    }
    var admin = await dbContext.Users.FirstOrDefaultAsync(x=>x.UserName == "admin");
    if (admin is null)
    {
      return;
    }
    var auClass = new List<Entities.AuClass>
    {
      new ()
      {
        Code = "user",
        Name = "người dùng",
        MenuName = "Quản lý người dùng",
        ParentId = null,
        AuActionClasses = [
          new()
          {
            Code = "ManagerUser",
            Name = "Danh sách người dùng",
            Path = "/quanlynhanvien",
            Permissions = [
              new(admin.Id),
            ]
          }
        ],
      },
      new()
      {
        Code = "contents",
        Name = "Bài viết",
        MenuName = "Quản lý bài viết",
        AuActionClasses = [
          new()
          {
            Code = "ManagerContents",
            Name = "Danh sách bài viết",
            Path = "/danhsachbaiviet",
            Permissions = [
              new(admin.Id),
            ]
          }
        ],
        Parent = null,
      },
      new(){
        Code = "subject",
        Name = "Chủ đề",
        MenuName = "Quản lý chủ đề bài viết",
        AuActionClasses = [
          new()
          {
            Code = "ManagerSubjects",
            Name = "Danh sách chủ đề",
            Path = "/danhsachchude",
            Permissions = [
              new(admin.Id),
            ]
          }
        ],
        ParentId = null,
      },
      new(){
        Code = "informations",
        Name = "Thông tin tổ chức",
        MenuName = "Quản lý thông tin tổ chức",
        AuActionClasses = [
          new()
          {
            Code = "ManagerInformations",
            Name = "Danh sách Thông tin tổ chức",
            Path = "/danhsachthongtintochuc",
            Permissions = [
              new(admin.Id),
            ]
          }
        ],
        ParentId = null,
      },
      new (){
        Code = "Authozization",
        Name = "Phân quyền",
        MenuName = "Quản lý quyền",
        AuActionClasses = [
          new()
          {
            Code = "ManagerAuthozization",
            Name = "Danh sách quyền",
            Path = "/danhsachquyen",
            Permissions = [
              new(admin.Id),
            ]
          }
        ],
        ParentId = null,
      },
      new()
      {
        Code = "FeedBacks",
        Name = "Phản hồi",
        MenuName = "Thông tin khách hàng",
        AuActionClasses = [
          new()
          {
            Code = "ManagerFeedBacks",
            Name = "Danh sách phản hồi khách hàng",
            Path = "/danhsachphanhoikhachhang",
            Permissions = [
              new(admin.Id),
            ]
          }
        ],
        ParentId = null,
      }
    };
    dbContext.AuClasses.AddRange(auClass);
    await dbContext.SaveChangesAsync();
  }
}

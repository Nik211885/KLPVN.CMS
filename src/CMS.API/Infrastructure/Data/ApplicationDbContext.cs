using System.Reflection;
using CMS.API.Entities;
using KLPVN.Core.Helper;
using KLPVN.Core.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace CMS.API.Infrastructure.Data;

public class ApplicationDbContext : DbContext
{
  private readonly IUserProvider _userProvider;
  public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IUserProvider userProviders)
    : base(options)
  {
    _userProvider = userProviders;
  }
  
  public DbSet<AuActionClass> AuActionClasses { get; set; }
  public DbSet<AuClass> AuClasses { get; set; }
  public DbSet<Content> Contents { get; set; }
  public DbSet<FeedBack> FeedBacks { get; set; }
  public DbSet<InformationOrganization> InformationOrganizations { get; set; }
  public DbSet<Permission> Permissions { get; set; }
  public DbSet<Role> Roles { get; set; }
  public DbSet<Subject> Subjects{ get; set; }
  public DbSet<SubjectContent> SubjectContents { get; set; }
  public DbSet<User> Users { get; set; }
  public DbSet<UserRole> UserRoles { get; set; }
  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    base.OnModelCreating(modelBuilder);
    modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
  }
  public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
  {
    var entries = ChangeTracker.Entries()
      .Where(e=>e.State is EntityState.Added or EntityState.Modified or EntityState.Deleted).ToList();
    foreach (var e in entries)
    {
      switch (e.State)
      {
        case EntityState.Added:
          HandlerAddedEntity(e);
          break;
        case EntityState.Deleted:
          HandlerDeletedEntity(e);
          break;
        case EntityState.Modified:
          HandlerModifiedEntity(e);
          break;
      }
    }
    return base.SaveChangesAsync(cancellationToken);
  }
  private void HandlerAddedEntity(EntityEntry entry)
  {
    var entity = entry.Entity;
    var type = entity.GetType();
    var properties = type.GetProperties();
    foreach (var p in properties)
    {
      var flags = 0;
      if (p.CanWrite)
      {
        switch (p.Name)
        {
          case "Id":
            if (p.GetValue(entity) is null)
            {
              // if type is int make sure it is serial
              if (p.PropertyType == typeof(string))
              {
                p.SetValue(entity, StringHelper.RandomKeyFormatDateTime());
                break;
              }
            }
            flags += 1;
            break;
          case "CreatedBy":
            flags += 1;
            if (p.PropertyType == typeof(string))
            {
              p.SetValue(entity,_userProvider.UserName);
            }
            break;
          case "CreatedDateTime":
            flags += 1;
            if (p.PropertyType == typeof(DateTimeOffset))
            {
              p.SetValue(entity, DateTimeOffset.UtcNow);
            }
            break;
          case "UpdatedBy":
            flags += 1;
            if (p.PropertyType == typeof(string))
            {
               p.SetValue(entity,_userProvider.UserName);
            }
            break;
          case "UpdatedDateTime":
            flags += 1;
            if (p.PropertyType == typeof(DateTimeOffset))
            {
              p.SetValue(entity, DateTimeOffset.UtcNow);
            }
            break;
        }
      }

      if (flags == 5)
      {
        break;
      }
    }
  }
  private void HandlerDeletedEntity(EntityEntry entry)
  {
    
  }
  private void HandlerModifiedEntity(EntityEntry entry)
  {
    var entity = entry.Entity;
    var type = entity.GetType();
    var properties = type.GetProperties();
    foreach (var p in properties)
    {
      int flags = 0;
      if (p.CanWrite)
      {
        switch (p.Name)
        {
          case "UpdatedBy":
            flags += 1;
            if (p.PropertyType == typeof(string))
            {
              p.SetValue(entity,_userProvider.UserName);
            }
            break;
          case "UpdatedDateTime":
            flags += 1;
            if (p.PropertyType == typeof(DateTimeOffset))
            {
              p.SetValue(entity, DateTimeOffset.UtcNow);
            }
            break;
        }
      }
      if (flags == 2)
      {
        break;
      }
    }
  }
}

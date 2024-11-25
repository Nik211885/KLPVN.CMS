using System.Reflection;
using CMS.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace CMS.API.Infrastructure.Data;

public class ApplicationDbContext : DbContext
{
  public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
    : base(options)
  {
    
  }  
  public DbSet<FeedBack> FeedBacks { get; set; }
  public DbSet<InformationOrganization> InformationOrganizations { get; set; }
  public DbSet<Subject> Subjects { get; set; }
  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    base.OnModelCreating(modelBuilder);
    modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
  }
}

using CMS.API.Common;
using KLPVN.Core.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace CMS.API.Infrastructure.Data;

public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
{
  public ApplicationDbContext CreateDbContext(string[] args)
  {
    var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
    var builder = new ConfigurationBuilder()
      .SetBasePath(Path.Combine(Directory.GetCurrentDirectory()))
      .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
    var config = builder.Build();
    optionsBuilder.UseNpgsql(config.GetConnectionString("DefaultConnection"));
    return new ApplicationDbContext(optionsBuilder.Options, new UserProvideDesignRuntime());
  }

  private class UserProvideDesignRuntime : IUserProvider
  {
    public bool IsAuthenticated { get; } = true;
    public Guid UserId { get; } = Guid.NewGuid();
    public string UserName { get; } = "Guest";
  }
}

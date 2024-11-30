using CMS.API.Common;
using KLPVN.Core.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace CMS.API.Infrastructure.Data;

public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
{
  private readonly IConfiguration _configuration;

  public ApplicationDbContextFactory(IConfiguration configuration)
  {
    _configuration = configuration;
  }
  public ApplicationDbContext CreateDbContext(string[] args)
  {
    var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
    optionsBuilder.UseNpgsql(_configuration.GetConnectionString("DefaultConnection") 
                             ?? throw new ArgumentException("Not config connection string"));
    return new ApplicationDbContext(optionsBuilder.Options, new UserProvideDesignRuntime());
  }

  private class UserProvideDesignRuntime : IUserProvider
  {
    public bool IsAuthenticated { get; } = true;
    public Guid UserId { get; } = Guid.NewGuid();
    public string UserName { get; } = "Guest";
  }
}

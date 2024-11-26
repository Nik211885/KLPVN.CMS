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
    optionsBuilder.UseNpgsql("Server=localhost;Port=5432;Database=klpvn_cms;Username=postgres;Password=211885;");
    return new ApplicationDbContext(optionsBuilder.Options, new UserProvideDesignRuntime());
  }
  public class UserProvideDesignRuntime : IUserProvider
  {
    public bool IsAuthenticated { get; } = true;
    public Guid UserId { get; } = Guid.NewGuid();
    public string UserName { get; } = "Guest";
  }
}

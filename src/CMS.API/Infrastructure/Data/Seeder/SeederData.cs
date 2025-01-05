namespace CMS.API.Infrastructure.Data.Seeder;

public static class SeederData
{
  public static async Task SeederAsync(IServiceProvider services)
  {
    using var scope = services.CreateScope();
    var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    await RoleSeeder.SeederAsync(dbContext);
    await UserSeeder.SeederAsync(dbContext);
    await PermissionSeeder.SeederAsync(dbContext);
    await AuClassSeeder.SeederAsync(dbContext);
    await SubjectSeeder.SeedAsync(dbContext);
    await FeedBack.SeedAsync(dbContext);
    await InformationOrganizationSeeder.SeederAsync(dbContext);
  }
}

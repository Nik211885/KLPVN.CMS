using CMS.API.Infrastructure.Data;
using KLPVN.Core.Interface;

namespace CMS.API.Services.sample;

public class Services : IServices
{
  private readonly ApplicationDbContext _context;

  public Services(ApplicationDbContext dbContext)
  {
    _context = dbContext;
  }
}

using CMS.API.Infrastructure.Data;
using KLPVN.Core.Interface;

namespace CMS.API.Services.FeedBack;

public class Services : IServices
{
  private readonly ApplicationDbContext _context;
  private readonly IUserProvider _userProvider;

  public Services(ApplicationDbContext dbContext, IUserProvider userProvider)
  {
    _context = dbContext;
    _userProvider = userProvider;
  }
}

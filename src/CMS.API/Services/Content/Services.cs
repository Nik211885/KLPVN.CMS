using KLPVN.Core.Interface;
using Microsoft.EntityFrameworkCore;

namespace CMS.API.Services.Content;

public class Services : IServices
{
  private readonly DbContext _context;
  private readonly IUserProvider _userProvider;

  public Services(DbContext dbContext, IUserProvider userProvider)
  {
    _context = dbContext;
    _userProvider = userProvider;
  }
}

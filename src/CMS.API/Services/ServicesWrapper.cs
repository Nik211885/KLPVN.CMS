using CMS.API.Infrastructure.Data;
using KLPVN.Core.Interface;

namespace CMS.API.Services;

public class ServicesWrapper : IServicesWrapper
{
  private readonly ApplicationDbContext _context;

  public ServicesWrapper(ApplicationDbContext context)
  {
    _context = context;
  }
  private AuClass.IServices _auClass;
  private Content.IServices _content;
  private FeedBack.IServices _feedBack;
  private InformationOrganization.IServices _informationOrganization;
  private Permission.IServices _permission;
  private Role.IServices _role;
  private sample.IServices _sample;
  private Subject.IServices _subject;
  private User.IServices _user;
  
  public AuClass.IServices AuClass => _auClass ??= new AuClass.Services(_context);
  public Content.IServices Content => _content ??= new Content.Services(_context);
  public FeedBack.IServices FeedBack => _feedBack ??= new FeedBack.Services(_context);
  public InformationOrganization.IServices InformationOrganization => _informationOrganization 
    ??= new InformationOrganization.Services(_context);
  public Permission.IServices Permission => _permission ??= new Permission.Services(_context);
  public Role.IServices Role => _role ??= new Role.Services(_context);
  public sample.IServices Sample => _sample ??= new sample.Services(_context);
  public Subject.IServices Subject => _subject ??= new Subject.Services(_context);
  public User.IServices User => _user ??= new User.Services(_context);
}

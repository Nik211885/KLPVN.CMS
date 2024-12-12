using KLPVN.Core.Models;

namespace CMS.API.Entities;

public class Permission
{
  public Guid ActionClassId { get;}
  public AuActionClass? ActionClass { get; init; }
  public Guid ObjectId { get; }

  public Permission()
  {
    
  }

  public Permission(Guid actionClassId, Guid objectId)
  {
    ActionClassId = actionClassId;
    ObjectId = objectId;
  }

  public Permission(Guid objectId)
  {
    ObjectId = objectId;
  }
}

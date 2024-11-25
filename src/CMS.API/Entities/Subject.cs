using KLPVN.Core.Models;

namespace CMS.API.Entities;

public class Subject : CoreEntity<Guid>
{
  public string Code { private get; set; } = null!;
  public string Name { private get; set; } = null!;
  public bool IsActive {private get; set; }
  public int DisplayOrder { private get; set; }
  public Guid? ParentId { private get; set; }
  public Subject? Parent { get; set; }
  public Subject()
    :base(default, default)
  {
    
  }
  public Subject(string createdBy, string code, string name, int displayOrder, Guid? parentId)
   : base(Guid.NewGuid(), createdBy)
  {
    Code = code;
    Name = name;
    IsActive = true;
    DisplayOrder = displayOrder;
    ParentId = parentId;
  }

  public void UpdateSubject(string updateBy, string code, string name, int displayOrder, Guid? parentId, bool? isActive = null)
  {
    base.UpdateCoreEntity(updateBy);
    Code = code;
    Name = name;
    DisplayOrder = displayOrder;
    ParentId = parentId;
    IsActive = isActive ?? IsActive;
  }

  public void UpdateActive(string updateBy, bool isActive)
  {
    base.UpdateCoreEntity(updateBy);
    IsActive = isActive;
  }
}

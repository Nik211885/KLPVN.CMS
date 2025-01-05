namespace CMS.Shared.DTOs.Subject.Response;

public class SubjectDetailResponse
{
  public Guid Id { get; set; }
  public string Code { get; set; }
  public string Name { get; set; }
  public bool IsActive { get; set; }

  public int DisplayOrder { get; set; }
  public  Guid? ParentId { get; set; }
  public string? ParentName { get; set; }
}

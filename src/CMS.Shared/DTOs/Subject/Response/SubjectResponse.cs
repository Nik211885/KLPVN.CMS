namespace CMS.Shared.DTOs.Subject.Response;

public class SubjectResponse
{
  public List<Subjects> SubjectsList { get; set; } = [];
}
public class Subjects
{
  public Guid Id { get; set; }
  public string Code { get; set; }
  public string Name { get; set; }
  public bool IsActive { get; set; }
  public int DisplayOrder { get; set; }
  public List<Subjects> Subject { get; set; } = [];
}

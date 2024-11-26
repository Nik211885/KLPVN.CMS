namespace CMS.API.Entities;

public class SubjectContent
{
  public Guid SubjectId { get; }
  public Guid ContentId { get; }
  public Subject? Subject { get; init; }
  public Content? Content { get; init; }

  public SubjectContent()
  {
    
  }

  public SubjectContent(Guid subjectId, Guid contentId)
  {
    SubjectId = subjectId;
    ContentId = contentId;
  }
}

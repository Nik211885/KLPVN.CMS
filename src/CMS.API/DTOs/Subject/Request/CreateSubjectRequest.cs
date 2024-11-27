namespace CMS.API.DTOs.Subject.Request;

public record CreateSubjectRequest(string Code, string Name, int DisplayOrder, Guid? ParentId);

public static class CreateSubjectRequestExtensions
{
  public static Entities.Subject Mapping(this CreateSubjectRequest request)
  {
    return new Entities.Subject()
    {
      Code = request.Code, 
      Name = request.Name, 
      DisplayOrder = request.DisplayOrder,
      ParentId = request.ParentId,
    };
  }

  public static bool IsValid(this CreateSubjectRequest request, out List<string> error)
  {
    error = [];
    if (String.IsNullOrWhiteSpace(request.Code))
    {
      error.Add("Mã chủ đề không được để trống");
    }
    if(string.IsNullOrWhiteSpace(request.Name))
    {
      error.Add("Tên của chủ đề không được để trống");
    }
    return error.Count == 0;
  }
}

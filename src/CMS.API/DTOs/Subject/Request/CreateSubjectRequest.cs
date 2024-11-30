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

    if (request.Code.Length > 50)
    {
      error.Add("Mã của chủ đề không lớn hơn 50 ký tự");
    }

    if (request.Name.Length > 75)
    {
      error.Add("Tên của chủ đề không lớn hơn 75 kí tự");
    }
    return error.Count == 0;
  }
}

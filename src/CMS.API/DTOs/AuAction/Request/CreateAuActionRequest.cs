namespace CMS.API.DTOs.AuAction.Request;

public record CreateAuActionRequest(string Code, string Name);

public static class CreateAuActionRequestExtensions
{
  public static Entities.AuAction Mapping(this CreateAuActionRequest request)
  {
    return new Entities.AuAction()
    {
      Code = request.Code,
      Name = request.Name
    };
  }
  public static bool IsValid(this CreateAuActionRequest request, out List<string> error)
  {
    error = [];
    if (String.IsNullOrWhiteSpace(request.Code))
    {
      error.Add("Mã action không được để trống");
    }
    if(string.IsNullOrWhiteSpace(request.Name))
    {
      error.Add("Tên của action không được để trống");
    }

    if (request.Code.Length > 50)
    {
      error.Add("Mã action không lớn hơn 50 ký tự");
    }

    if (request.Name.Length > 50)
    {
      error.Add("Tên của action không lơn hơn 50 ký tự");
    }
    return error.Count == 0;
  }
}

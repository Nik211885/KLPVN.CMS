namespace CMS.API.DTOs.Au.Request;

public record LoginRequest(string UserName, string Password);

public static class LoginRequestExtensions
{
  public static bool IsValid(this LoginRequest request, out List<string> errors)
  {
    errors = [];
    if (string.IsNullOrWhiteSpace(request.UserName))
    {
      errors.Add("User name không được để trống");
    }

    if (string.IsNullOrWhiteSpace(request.Password))
    {
      errors.Add("Mật khẩu không được để trống");
    }
    return errors.Count == 0;
  }
}

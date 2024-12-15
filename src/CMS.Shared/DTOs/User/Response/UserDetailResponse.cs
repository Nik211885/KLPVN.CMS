namespace CMS.Shared.DTOs.User.Response;

public record UserDetailResponse(string FullName, 
  string? Email, 
  bool Gender,
  string Phone, 
  string? Address, 
  string? Avatar);

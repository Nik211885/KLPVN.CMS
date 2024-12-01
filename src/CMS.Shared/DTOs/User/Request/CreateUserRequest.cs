namespace CMS.Shared.DTOs.User.Request;

public record CreateUserRequest(string UserName,
  string PhoneNumber,
  string? Email,
  string? Address,
  string FullName,
  string Password,
  bool Gender, 
  string? Avatar);
  

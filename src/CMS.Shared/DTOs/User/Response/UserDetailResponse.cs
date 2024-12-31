using CMS.Shared.DTOs.Role.Response;

namespace CMS.Shared.DTOs.User.Response;

public record UserDetailResponse(
  Guid Id,
  string FullName, 
  string? Email, 
  bool Gender,
  string Phone, 
  string? Address, 
  string Avatar);

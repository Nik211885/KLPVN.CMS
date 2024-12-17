namespace CMS.Shared.DTOs.User.Request;

public record UpdateUserInformationRequest(
  string PhoneNumber,
  string? Email,
  string? Address,
  string FullName,
  bool Gender);
  

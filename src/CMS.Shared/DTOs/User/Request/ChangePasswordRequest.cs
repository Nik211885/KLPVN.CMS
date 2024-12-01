namespace CMS.Shared.DTOs.User.Request;

public record ChangePasswordRequest(string Password, string NewPassword, string PasswordConfirm);

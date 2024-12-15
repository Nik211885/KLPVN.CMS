namespace CMS.Shared.DTOs.Au.Response;

public record UserDecodeAccessToken(string UserName, IEnumerable<string>? Roles);

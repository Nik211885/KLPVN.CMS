namespace CMS.Shared.DTOs.FeedBack.Request;

public record CreateFeedBackRequest(
  string FullName,
  string Phone,
  string Title,
  string? Email,
  string? Note,
  string? Address);


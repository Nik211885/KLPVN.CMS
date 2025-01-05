namespace CMS.Shared.DTOs.InfromationOrgaization.Response;

public record InformationOrganizationResponse(
  Guid Id, 
  string Code, 
  string OrganizationName,
  string Address,
  string Phone,
  string? Email,
  string? Icon,
  string? RefFacebook,
  string? RefYoutube,
  string? RefX,
  string? RefSocial,
  string? RefTikTok,
  bool IsActive
);

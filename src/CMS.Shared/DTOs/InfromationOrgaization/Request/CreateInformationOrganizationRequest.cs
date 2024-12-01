namespace CMS.Shared.DTOs.InfromationOrgaization.Request;

public record CreateInformationOrganizationRequest(
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
  string? RefTikTok);


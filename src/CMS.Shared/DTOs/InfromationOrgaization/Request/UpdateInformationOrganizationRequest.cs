namespace CMS.Shared.DTOs.InfromationOrgaization.Request;

public record UpdateInformationOrganizationRequest(
  string Code, 
  string OrganizationName, 
  string Address,
  string Phone, 
  string? Email,
  string? RefFacebook, 
  string? RefYoutube,  
  string? RefX, 
  string? RefSocial, 
  string? RefTikTok); 

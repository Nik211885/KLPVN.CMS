﻿using CMS.API.DTOs.InfromationOrgaization.Request;

namespace CMS.API.Services.InformationOrganization;

public interface IServices
{
  Task<Guid> CreateAsync(CreateInformationOrganizationRequest request);
  Task<Guid> UpdateAsync(Guid id, UpdateInformationOrganizationRequest request);
  Task<Guid> ActiveAsync(Guid id);
}

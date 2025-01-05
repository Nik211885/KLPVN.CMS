using CMS.API.Common.Mapping;
using CMS.API.Common.Message;
using CMS.API.Common.Validation;
using CMS.API.Exceptions;
using CMS.API.Infrastructure.Data;
using CMS.Shared.DTOs.InfromationOrgaization.Request;
using CMS.Shared.DTOs.InfromationOrgaization.Response;
using KLPVN.Core.Interface;
using Microsoft.EntityFrameworkCore;

namespace CMS.API.Services.InformationOrganization;

public class Services : IServices
{
  private readonly ApplicationDbContext _context;

  public Services(ApplicationDbContext dbContext)
  {
    _context = dbContext;
  }

  public async Task<Guid> CreateAsync(CreateInformationOrganizationRequest request)
  {
    request.IsValid();
    var informationOr = request.Mapping();
    var informationOrAfter = await _context.InformationOrganizations
      .FirstOrDefaultAsync(x => x.IsActive);
    informationOr.IsActive = informationOrAfter is null;
    _context.InformationOrganizations.Add(informationOr);
    await _context.SaveChangesAsync();
    return informationOr.Id;
  }

  public async Task<Guid> UpdateAsync(Guid id, UpdateInformationOrganizationRequest request)
  {
    request.IsValid();

    var informationOr = await _context.InformationOrganizations
      .FirstOrDefaultAsync(x => x.Id == id);
    if (informationOr is null)
    {
      throw new NotFoundException(nameof(Entities.InformationOrganization));
    }
    
    request.Mapping(informationOr);
    _context.InformationOrganizations.Update(informationOr);
    await _context.SaveChangesAsync();
    return id;
  }

  public async Task<Guid> ActiveAsync(Guid id)
  {
    var informationOr = await _context.InformationOrganizations
      .FirstOrDefaultAsync(x => x.Id == id);
    if (informationOr is null)
    {
      throw new NotFoundException(nameof(InformationOrganization));
    } 

    if (!informationOr.IsActive)
    {
      var informationActive = await _context.InformationOrganizations
        .FirstOrDefaultAsync(x => x.IsActive);
      if (informationActive is not null)
      {
        throw new BadRequestException(ConstMessage.INFORMATION_ORGANIZATION_HAS_ACTIVE_BEFORE);
      }
      informationOr.IsActive = true;
    }

    informationOr.IsActive = false;
    _context.InformationOrganizations.Update(informationOr);
    await _context.SaveChangesAsync();
    return id;
  }

  public async Task<List<InformationOrganizationResponse>> GetAllAsync()
  {
    var informationOrganizations = await _context.InformationOrganizations.ToListAsync();
    var result = informationOrganizations.Mapping();
    return result;
  }

  public async Task DeleteAsync(Guid id)
  {
    var informationOr = await _context.InformationOrganizations.FirstOrDefaultAsync(x => x.Id == id);
    if (informationOr is null)
    {
      throw new NotFoundException(nameof(InformationOrganization));
    }
    _context.InformationOrganizations.Remove(informationOr);
    await _context.SaveChangesAsync();
  }

  public async Task<Guid> UploadIconAsync(Guid id, string iconUrl)
  {
    var informationOr = await _context.InformationOrganizations.FirstOrDefaultAsync(x => x.Id == id);
    if (informationOr is null)
    {
      throw new NotFoundException(nameof(InformationOrganization));
    }
    informationOr.Icon = iconUrl;
    _context.InformationOrganizations.Update(informationOr);
    await _context.SaveChangesAsync();
    return informationOr.Id;
  }
}

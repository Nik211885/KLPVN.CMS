using CMS.API.DTOs.Au.Request;
using KLPVN.Core.Models;
using Microsoft.AspNetCore.Identity.Data;
using LoginRequest = CMS.API.DTOs.Au.Request.LoginRequest;

namespace CMS.API.Services.Au;

public interface IServices
{
  Task<JwtResult> LoginAsync(LoginRequest request);
}

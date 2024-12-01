using CMS.Shared.DTOs.Au.Request;
using KLPVN.Core.Models;

namespace CMS.API.Services.Au;

public interface IServices
{
  Task<JwtResult> LoginAsync(LoginRequest request);
}

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.Data;
using ProjectHub.Api.DTOs.Requests;

namespace ProjectHub.Api.Services.Interfaces;

public interface IAuthService
{
    Task<IdentityResult> RegisterAsync(UserRegisterRequest request);
    Task<Guid?> LoginAsync(LoginRequest request);
}

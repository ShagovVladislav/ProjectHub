using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.Data;
using ProjectHub.Api.Domain;
using ProjectHub.Api.DTOs.Requests;
using ProjectHub.Api.Services.Interfaces;

namespace ProjectHub.Api.Services;

public class AuthService(UserManager<ApplicationUser> userManager) : IAuthService
{
    public Task<IdentityResult> RegisterAsync(UserRegisterRequest request)
    {
        var now = DateTimeOffset.UtcNow;
        var user = new ApplicationUser
        {
            Email = request.Email,
            UserName = request.Username,
            DisplayName = request.DisplayName,
            CreatedAt = now,
            UpdatedAt = now
        };

        return userManager.CreateAsync(user, request.Password);
    }

    public async Task<Guid?> LoginAsync(LoginRequest request)
    {
        var user = await userManager.FindByEmailAsync(request.Email);

        if (user is null || !await userManager.CheckPasswordAsync(user, request.Password))
            return null;

        return user.Id;
    }
}

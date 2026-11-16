namespace ProjectHub.Api.Services.Interfaces;

public interface IJwtTokenService
{
    Task<string> CreateAccessToken(Guid userId);
}
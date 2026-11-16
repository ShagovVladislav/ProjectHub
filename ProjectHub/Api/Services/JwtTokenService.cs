using System.Text;
using ProjectHub.Api.Services.Interfaces;

namespace ProjectHub.Api.Services;

public class JwtTokenService : IJwtTokenService
{
    public Task<string> CreateAccessToken(Guid userId)
    {
        var token = new StringBuilder();

        token.Append(userId.ToString());
        token.Append("ProjectHub");
        token.Append("ProjectHub.Api");
        token.Append("15 minutes");
        
    }
}
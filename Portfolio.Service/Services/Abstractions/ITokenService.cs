using Portfolio.Core.Models;

namespace Portfolio.Service.Services.Abstractions
{
    public interface ITokenService
    {
        string GenerateAccessToken(Author author, string role);
        string GenerateRefreshToken();
    }
}

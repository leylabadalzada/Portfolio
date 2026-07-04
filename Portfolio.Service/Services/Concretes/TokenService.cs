using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Portfolio.Core.Models;
using Portfolio.Service.Services.Abstractions;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace Portfolio.Service.Services.Concretes
{
    public class TokenService : ITokenService
    {
        readonly IConfiguration _config;

        public TokenService(IConfiguration config)
        {
            _config = config;
        }

        public string GenerateAccessToken(Author author, string role)
        {
            var issuer = _config["JWT:issuer"];
            var audience = _config["JWT:audience"];
            var expiresIn = Convert.ToInt32(_config["JWT:expiresIn"]);

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, author.Id),
                new Claim(ClaimTypes.Name, author.UserName),
                new Claim(ClaimTypes.Email, author.Email),
                new Claim(ClaimTypes.Role, role)
            };



            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JWT:securityKey"]));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: issuer,
                audience: audience,
                claims: claims,
                signingCredentials: credentials,
                expires: DateTime.UtcNow.AddHours(4 + expiresIn)
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public string GenerateRefreshToken()
        {
            var randomNumber = new byte[32];
            using var rng = RandomNumberGenerator.Create();
            rng.GetBytes(randomNumber);
            return Convert.ToBase64String(randomNumber);
        }
    }
}

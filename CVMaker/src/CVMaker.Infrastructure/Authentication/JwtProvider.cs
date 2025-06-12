using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using CVMaker.Domain.Entities;
using CVMaker.Application.Abstractions.Authentication;
using Microsoft.Extensions.Configuration;

namespace CVMaker.Infrastructure.Authentication
{
    public class JwtProvider : IJwtProvider
    {
        private readonly IConfiguration _Configuration;

        public JwtProvider(IConfiguration configuration)
        {
            _Configuration = configuration;
        }

        public string GenerateToken(User user)
        {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.UTF8.GetBytes(_Configuration["JwtSettings:Secret"]);

                var claims = new List<Claim>
                {
                    new Claim(JwtRegisteredClaimNames.Sub, user.Email),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.Email, user.Email),
                    new Claim("userId", user.ExternalId.ToString())
                   };

                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(claims),
                    Expires = DateTime.UtcNow.AddMinutes(
                        double.Parse(_Configuration["JwtSettings:JwtExpirationMinutes"])),
                    Issuer = _Configuration["JwtSettings:Secret"],
                    Audience = _Configuration["JwtSettings:Secret"],
                    SigningCredentials = new SigningCredentials(
                        new SymmetricSecurityKey(key),
                        SecurityAlgorithms.HmacSha256Signature)
                };

                var token = tokenHandler.CreateToken(tokenDescriptor);
                return tokenHandler.WriteToken(token);

            }
            
            }
} 
    

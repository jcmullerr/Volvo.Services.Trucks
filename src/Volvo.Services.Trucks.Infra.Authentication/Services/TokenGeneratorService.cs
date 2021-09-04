using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Volvo.Services.Trucks.Domain.Entities.Security;
using Volvo.Services.Trucks.Domain.Interfaces.Authentication;
using Volvo.Services.Trucks.Infra.CrossCutting;
using Volvo.Services.Trucks.Infra.CrossCutting.Settings;

namespace Volvo.Services.Trucks.Infra.Authentication.Services
{
    public class TokenGeneratorService : ITokenGeneratorService
    {
        private readonly AuthSettings _settings;

        public TokenGeneratorService(AuthSettings settings)
        {
            _settings = settings;
        }

        public string GenerateToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_settings.Key);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name,user.Name.ToString())
                }),
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
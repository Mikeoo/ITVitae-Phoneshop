using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Phoneshop.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace Phoneshop.Business
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration _configuration;

        public TokenService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public string Generate(List<Claim> claims)
        {

            if (claims is null || !claims.Any())
                throw new ArgumentNullException(nameof(claims));
            var mySecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("Jwt").GetSection("Key").Value));
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddDays(7),
                Issuer = _configuration["Jwt:Issuer"],
                Audience = _configuration["Jwt:Audience"],
                SigningCredentials = new SigningCredentials(
                    mySecurityKey, SecurityAlgorithms.HmacSha256Signature)
            });
            return tokenHandler.WriteToken(token);
        }
    }
}

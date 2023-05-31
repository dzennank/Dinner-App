using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using BuberDuinner.Application.Common.Interfaces.Authentication;
using BuberDuinner.Application.Common.Interfaces.Authentication.Services;
using Microsoft.IdentityModel.Tokens;

namespace BuberDinner.Infrastructure.Authentication
{
    public class JwtTokenGenerator : IJwtTokenGenerator
    {
        private readonly IDateTimeProvider _dateProvider;

        public JwtTokenGenerator(IDateTimeProvider dateProvider)
        {
            _dateProvider = dateProvider;
        }
        public string TokenGenerator(Guid userId, string firstName, string lastName)
        {
            
            var signingCredentials = new SigningCredentials(
                new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes("super-secret-key-super-secret-key")),
                    SecurityAlgorithms.HmacSha256
                );
            
              var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, userId.ToString()),
            new Claim(JwtRegisteredClaimNames.GivenName, firstName),
            new Claim(JwtRegisteredClaimNames.FamilyName, lastName),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

        var securityToken = new JwtSecurityToken(
            issuer: "BuberDinner",
            expires:_dateProvider.UtcNow.AddMinutes(60),
            claims: claims,
            signingCredentials: signingCredentials
        );
        return new JwtSecurityTokenHandler().WriteToken(securityToken);
        }
    }
}
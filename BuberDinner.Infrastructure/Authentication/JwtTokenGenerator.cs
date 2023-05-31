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
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace BuberDinner.Infrastructure.Authentication
{
    public class JwtTokenGenerator : IJwtTokenGenerator
    {
        private readonly IDateTimeProvider _dateProvider;
        private readonly JwtSettings _jwtSettings;

        public JwtTokenGenerator(IDateTimeProvider dateProvider, IOptions<JwtSettings> jwtOptions)
        {
            _dateProvider = dateProvider;
            _jwtSettings = jwtOptions.Value;
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
            issuer: _jwtSettings.Issuer,
            expires:_dateProvider.UtcNow.AddMinutes(_jwtSettings.ExpiryMinutes),
            claims: claims,
            signingCredentials: signingCredentials
        );
        return new JwtSecurityTokenHandler().WriteToken(securityToken);
        }
    }
}
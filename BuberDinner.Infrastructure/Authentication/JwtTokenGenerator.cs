using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using BuberDuinner.Application.Common.Interfaces.Authentication;
using Microsoft.IdentityModel.Tokens;

namespace BuberDinner.Infrastructure.Authentication
{
    public class JwtTokenGenerator : IJwtTokenGenerator
    {
        public string TokenGenerator(Guid userId, string firstName, string lastName)
        {
                // Generate a random key
            //     var key = new byte[32]; // 256 bits = 32 bytes
            //     using (var rng = RandomNumberGenerator.Create())
            //     {
            //         rng.GetBytes(key);
            //     }
            
            // var base64Key = Convert.ToBase64String(key);
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
            expires: DateTime.Now.AddDays(1),
            claims: claims,
            signingCredentials: signingCredentials
        );
        return new JwtSecurityTokenHandler().WriteToken(securityToken);
        }
    }
}
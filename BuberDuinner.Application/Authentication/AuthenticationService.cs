using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BuberDuinner.Application.Common.Interfaces.Authentication;
using static BuberDuinner.Application.Authentication.AuthenticationResult;

namespace BuberDuinner.Application.Authentication
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IJwtTokenGenerator _jwtTokenGenerator;

        public AuthenticationService(IJwtTokenGenerator jwtTokenGenerator)
        {
           _jwtTokenGenerator = jwtTokenGenerator;
        }
        public AuthResult Register(string FirstName, string LastName, string Email, string password)
        {
            var userId = Guid.NewGuid();
            var token = _jwtTokenGenerator.TokenGenerator(userId, FirstName, LastName);
             
            return new AuthResult(
                userId,
                FirstName,
                LastName,
                Email,
                token
                );
        }

        public AuthResult Login(string email, string password)
        {
            return new AuthResult(
                Guid.NewGuid(),
                "FirstName",
                "LastName",
                email,
                "token"
                );
        }

        
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static BuberDuinner.Application.Authentication.AuthenticationResult;

namespace BuberDuinner.Application.Authentication
{
    public class AuthenticationService : IAuthenticationService
    {
        public AuthResult Register(string FirstName, string LastName, string Email, string password)
        {
            return new AuthResult(
                Guid.NewGuid(),
                FirstName,
                LastName,
                Email,
                "token"
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
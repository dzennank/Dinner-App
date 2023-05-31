using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BuberDuinner.Application.Authentication
{
    public class AuthenticationResult
    {
        public record AuthResult(Guid Id, 
        string FirstName, 
        string LastName, 
        string Email, 
        string Token
        );
    }
}
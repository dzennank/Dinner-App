using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static BuberDuinner.Application.Authentication.AuthenticationResult;

namespace BuberDuinner.Application.Authentication
{
    public interface IAuthenticationService
    {
        AuthResult Register(string FirstName, 
        string LastName, 
        string Email,
        string password);

        AuthResult Login(string email, string password);
    }
}
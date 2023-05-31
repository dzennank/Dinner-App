using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BuberDinner.Domen.Entities;

namespace BuberDuinner.Application.Authentication
{
    public class AuthenticationResult
    {
        public record AuthResult(
        User user,
        string Token
        );
    }
}
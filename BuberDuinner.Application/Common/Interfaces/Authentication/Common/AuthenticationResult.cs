
using BuberDinner.Domen.Entities;

namespace BuberDuinner.Application.Common.Interfaces.Authentication.Common
{
    public class AuthenticationResult
    {
        public record AuthResult(
        User user,
        string Token
        );
    }
}
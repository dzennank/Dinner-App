using ErrorOr;
using static BuberDuinner.Application.Authentication.AuthenticationResult;

namespace BuberDuinner.Application.Authentication
{
    public interface IAuthenticationService
    {
       
        ErrorOr<AuthResult> Register(string FirstName, 
        string LastName, 
        string Email,
        string password);

        ErrorOr<AuthResult> Login(string email, string password);
    }
}
using ErrorOr;
using static BuberDuinner.Application.Common.Interfaces.Authentication.Common.AuthenticationResult;

namespace BuberDuinner.Application.Common.Interfaces.Authentication.Commands
{
    public interface IAuthenticationCommandService
    {
       
        ErrorOr<AuthResult> Register(string FirstName, 
        string LastName, 
        string Email,
        string password);

    }
}
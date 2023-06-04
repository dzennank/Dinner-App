using ErrorOr;
using static BuberDuinner.Application.Common.Interfaces.Authentication.Common.AuthenticationResult;

namespace BuberDuinner.Application.Common.Interfaces.Authentication.Queries
{
    public interface IAuthenticationQueryService
    {
       

        ErrorOr<AuthResult> Login(string email, string password);
    }
}
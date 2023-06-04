
using ErrorOr;
using MediatR;
using static BuberDuinner.Application.Common.Interfaces.Authentication.Common.AuthenticationResult;

namespace BuberDuinner.Application.Authentication.Queries.Login
{
    public record LoginQuery(
        string Email,
        string Password) : IRequest<ErrorOr<AuthResult>>;// this is what cmd should return
}


using ErrorOr;
using MediatR;
using static BuberDuinner.Application.Common.Interfaces.Authentication.Common.AuthenticationResult;

namespace BuberDuinner.Application.Authentication.Commands.Register
{


public record RegisterCommand(
    string FirstName,
    string LastName,
    string Email,
    string Password) : IRequest<ErrorOr<AuthResult>>;// this is what cmd should return
}
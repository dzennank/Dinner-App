
using BuberDuinner.Application.Authentication.Commands.Register;
using BuberDuinner.Application.Common.Interfaces.Authentication.Common;
using ErrorOr;
using MediatR;

namespace BuberDuinner.Application.Common.Behaviors
{
    public class ValidateRegisterCommandBehavior : IPipelineBehavior<RegisterCommand, ErrorOr<AuthenticationResult>>
    {
        public async Task<ErrorOr<AuthenticationResult>> Handle(
            RegisterCommand request,
            RequestHandlerDelegate<ErrorOr<AuthenticationResult>> next,
            CancellationToken cancellationToken)
        {
            var result = await next();
            return result;
        }
    }
}
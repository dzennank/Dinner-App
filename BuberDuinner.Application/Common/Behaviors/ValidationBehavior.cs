
using BuberDuinner.Application.Authentication.Commands.Register;
// using BuberDuinner.Application.Common.Interfaces.Authentication.Common;
using ErrorOr;
using FluentValidation;
using MediatR;
using static BuberDuinner.Application.Common.Interfaces.Authentication.Common.AuthenticationResult;

namespace BuberDuinner.Application.Common.Behaviors
{
    public class ValidateRegisterCommandBehavior : IPipelineBehavior<RegisterCommand, ErrorOr<AuthResult>>
    {
        private readonly IValidator<RegisterCommand> _validator;

        public ValidateRegisterCommandBehavior(IValidator<RegisterCommand> validator)
        {
            _validator = validator;
        }
        public async Task<ErrorOr<AuthResult>> Handle(
            RegisterCommand request,
            RequestHandlerDelegate<ErrorOr<AuthResult>> next,
            CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(request, cancellationToken);
            if(validationResult.IsValid)
            {
                return await next();
            }
            var errors = validationResult.Errors.
            ConvertAll(validationFailure => Error.Validation(validationFailure.PropertyName,validationFailure.ErrorMessage));
            return errors;
        }
    }
}
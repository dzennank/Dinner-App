
using BuberDuinner.Application.Authentication.Commands.Register;
// using BuberDuinner.Application.Common.Interfaces.Authentication.Common;
using ErrorOr;
using FluentValidation;
using MediatR;
using static BuberDuinner.Application.Common.Interfaces.Authentication.Common.AuthenticationResult;

namespace BuberDuinner.Application.Common.Behaviors
{
    public class ValidatioBehavior<TRequest, TResponse> : 
            IPipelineBehavior<TRequest, TResponse>
                where TRequest : IRequest<TResponse>
                where TResponse : IErrorOr
    {
        private readonly IValidator<TRequest>? _validator;

        public ValidatioBehavior(IValidator<TRequest>? validator = null)
        {
            _validator = validator;
        }
        public async Task<TResponse> Handle(
            TRequest request,
            RequestHandlerDelegate<TResponse> next,
            CancellationToken cancellationToken)
        {
            if(_validator is null) 
            {
                return await next();
            }
            var validationResult = await _validator.ValidateAsync(request, cancellationToken);
            if(validationResult.IsValid)
            {
                return await next();
            }
            var errors = validationResult.Errors.
            ConvertAll(validationFailure => Error.Validation(validationFailure.PropertyName,validationFailure.ErrorMessage));
            return (dynamic)errors; //
        }
    }
}
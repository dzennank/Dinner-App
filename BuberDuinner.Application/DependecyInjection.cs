

using System.Reflection;
using BuberDuinner.Application.Authentication.Commands.Register;
using BuberDuinner.Application.Common.Behaviors;
// using BuberDuinner.Application.Common.Interfaces.Authentication.Common;
using ErrorOr;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using static BuberDuinner.Application.Common.Interfaces.Authentication.Common.AuthenticationResult;

namespace BuberDuinner.Application
{
    public static class DependecyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services) {
            // services.AddMediatR(typeof(DependecyInjection).Assembly);
           services.AddMediatR(cfg=>cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
           services.AddScoped(
            typeof(IPipelineBehavior<,>),
            typeof(ValidatioBehavior<,>));
           services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            return services;
        }
    }
}
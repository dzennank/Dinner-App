

using System.Reflection;
using BuberDuinner.Application.Authentication.Commands.Register;
using BuberDuinner.Application.Common.Behaviors;
using BuberDuinner.Application.Common.Interfaces.Authentication.Common;
using ErrorOr;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace BuberDuinner.Application
{
    public static class DependecyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services) {
            // services.AddMediatR(typeof(DependecyInjection).Assembly);
           services.AddMediatR(cfg=>cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
           services.AddScoped<IPipelineBehavior<RegisterCommand, ErrorOr<AuthenticationResult>>, ValidateRegisterCommandBehavior>();
            return services;
        }
    }
}
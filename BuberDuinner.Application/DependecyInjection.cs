

using System.Reflection;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace BuberDuinner.Application
{
    public static class DependecyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services) {
            // services.AddMediatR(typeof(DependecyInjection).Assembly);
           services.AddMediatR(cfg=>cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
            return services;
        }
    }
}
using Microsoft.Extensions.DependencyInjection;

namespace BuberDuinner.Application
{
    public static class DependecyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services) {
            return services;
        }
    }
}
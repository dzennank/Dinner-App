using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BuberDinner.Infrastructure.Authentication;
using BuberDinner.Infrastructure.Services;
using BuberDuinner.Application.Common.Interfaces.Authentication;
using BuberDuinner.Application.Common.Interfaces.Authentication.Services;
using Microsoft.Extensions.DependencyInjection;

namespace BuberDinner.Infrastructure
{
    public static class DependecyInjection
    {
          public static IServiceCollection AddInfrastructure(this IServiceCollection services) 
        {
            services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
            services.AddSingleton<IDateTimeProvider, DateProvider>();
            return services;
        }
    }
}
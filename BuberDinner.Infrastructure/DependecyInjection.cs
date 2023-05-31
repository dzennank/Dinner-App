using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BuberDinner.Infrastructure.Authentication;
using BuberDuinner.Application.Common.Interfaces.Authentication;
using Microsoft.Extensions.DependencyInjection;

namespace BuberDinner.Infrastructure
{
    public static class DependecyInjection
    {
          public static IServiceCollection AddInfrastructure(this IServiceCollection services) 
        {
            services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
            return services;
        }
    }
}
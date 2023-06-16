using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BuberDinner.Contracts.Authentication;
using BuberDuinner.Application.Authentication.Commands.Register;
using BuberDuinner.Application.Authentication.Queries.Login;
using BuberDuinner.Application.Common.Interfaces.Authentication.Common;
using Mapster;
using static BuberDuinner.Application.Common.Interfaces.Authentication.Common.AuthenticationResult;

namespace BuberDinner.Api.Mapping
{
    public class AuthenticationMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<RegisterRequest, RegisterCommand>();
            
            config.NewConfig<LoginRequest, LoginQuery>();

            config.NewConfig<AuthResult, AuthResponse>()
            .Map(dest => dest.Token, dest => dest.Token)
            .Map(dest => dest, src => src.user);
        }
    }
}
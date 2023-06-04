using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BuberDinner.Domen.Common.Errors;
using BuberDinner.Domen.Entities;

using BuberDuinner.Application.Common.Interfaces.Persistence;
using ErrorOr;
using static BuberDuinner.Application.Common.Interfaces.Authentication.Common.AuthenticationResult;

namespace BuberDuinner.Application.Common.Interfaces.Authentication.Queries
{
    public class AuthenticationQueryService : IAuthenticationQueryService
    {
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        private readonly IUserRepository _userRepository;

        public AuthenticationQueryService(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
        {
           _jwtTokenGenerator = jwtTokenGenerator;
            _userRepository = userRepository;
        }

        public ErrorOr<AuthResult> Login(string email, string password)
        {
            if(_userRepository.GetUserByEmail(email) is not User user) {
            
                return ErrorsUser.InvalidCredentials;
            }
            if(user.Password != password) {
                 return new[] { ErrorsUser.InvalidCredentials };
            }
            var token = _jwtTokenGenerator.TokenGenerator(user.Id, user.FirstName, user.LastName);
            return new AuthResult(
               user,
                token
                );
        }

        
    }
}
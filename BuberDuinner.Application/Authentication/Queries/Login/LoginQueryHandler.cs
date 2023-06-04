

using BuberDinner.Domen.Common.Errors;
using BuberDinner.Domen.Entities;
using BuberDuinner.Application.Common.Interfaces.Authentication;
using BuberDuinner.Application.Common.Interfaces.Persistence;
using ErrorOr;
using MediatR;
using static BuberDuinner.Application.Common.Interfaces.Authentication.Common.AuthenticationResult;

namespace BuberDuinner.Application.Authentication.Queries.Login
{

    
    public class LoginQueryHandler : IRequestHandler<LoginQuery, ErrorOr<AuthResult>>
    {
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        private readonly IUserRepository _userRepository;

        public LoginQueryHandler(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
        {
            _jwtTokenGenerator = jwtTokenGenerator;
            _userRepository = userRepository;
        }

        public async Task<ErrorOr<AuthResult>> Handle(LoginQuery query, CancellationToken cancellationToken)
        {
            if(_userRepository.GetUserByEmail(query.Email) is not User user) {
            
                return ErrorsUser.InvalidCredentials;
            }
            if(user.Password != query.Password) {
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
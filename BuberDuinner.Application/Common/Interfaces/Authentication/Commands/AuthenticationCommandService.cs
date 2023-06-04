
using BuberDinner.Domen.Common.Errors;
using BuberDinner.Domen.Entities;
using BuberDuinner.Application.Common.Interfaces.Persistence;
using ErrorOr;
using static BuberDuinner.Application.Common.Interfaces.Authentication.Common.AuthenticationResult;

namespace BuberDuinner.Application.Common.Interfaces.Authentication.Commands
{
    public class AuthenticationCommandService : IAuthenticationCommandService
    {
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        private readonly IUserRepository _userRepository;

        public AuthenticationCommandService(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
        {
           _jwtTokenGenerator = jwtTokenGenerator;
            _userRepository = userRepository;
        }
        public  ErrorOr<AuthResult> Register(string FirstName, string LastName, string Email, string password)
        {
            //Validate user
            if(_userRepository.GetUserByEmail(Email) is not null) {
                return ErrorsUser.DublicateEmail;
            }
            var user = new User {FirstName = FirstName, LastName = LastName, Email = Email, Password = password};
            _userRepository.Add(user);
            var userId = user.Id;
            var token = _jwtTokenGenerator.TokenGenerator(userId, FirstName, LastName);
             
            return new AuthResult(
                user,
                token
                );
        }
        
    }
}
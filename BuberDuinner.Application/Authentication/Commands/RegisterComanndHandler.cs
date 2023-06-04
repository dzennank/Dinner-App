using BuberDinner.Domen.Common.Errors;
using BuberDinner.Domen.Entities;
using BuberDuinner.Application.Authentication.Commands.Register;
using BuberDuinner.Application.Common.Interfaces.Authentication;
using BuberDuinner.Application.Common.Interfaces.Persistence;
using ErrorOr;
using MediatR;
using static BuberDuinner.Application.Common.Interfaces.Authentication.Common.AuthenticationResult;

namespace BuberDuinner.Application.Authentication.Commands
{
    public class RegisterComanndHandler : IRequestHandler<RegisterCommand, ErrorOr<AuthResult>>
    {
         private readonly IJwtTokenGenerator _jwtTokenGenerator;
        private readonly IUserRepository _userRepository;

        public RegisterComanndHandler(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
        {
            _jwtTokenGenerator = jwtTokenGenerator;
            _userRepository = userRepository;
        }

        public async Task<ErrorOr<AuthResult>> Handle(RegisterCommand command, CancellationToken cancellationToken)
        {

            //Validate user
            if(_userRepository.GetUserByEmail(command.Email) is not null) {
                return ErrorsUser.DublicateEmail;
            }
            var user = new User {
            FirstName = command.FirstName, 
            LastName = command.LastName, 
            Email = command.Email, 
            Password = command.Password};
            _userRepository.Add(user);
            var userId = user.Id;
            var token = _jwtTokenGenerator.TokenGenerator(userId, command.FirstName, command.LastName);
             
            return new AuthResult(
                user,
                token
                );
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BuberDinner.Domen.Entities;
using BuberDuinner.Application.Common.Interfaces.Authentication;
using BuberDuinner.Application.Common.Interfaces.Persistence;
using static BuberDuinner.Application.Authentication.AuthenticationResult;

namespace BuberDuinner.Application.Authentication
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        private readonly IUserRepository _userRepository;

        public AuthenticationService(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
        {
           _jwtTokenGenerator = jwtTokenGenerator;
            _userRepository = userRepository;
        }
        public AuthResult Register(string FirstName, string LastName, string Email, string password)
        {
            //Validate user
            if(_userRepository.GetUserByEmail(Email) is not null) {
                throw new Exception("User already exists");
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

        public AuthResult Login(string email, string password)
        {
            if(_userRepository.GetUserByEmail(email) is not User user) {
            
                throw new Exception("User does not exists");
            }
            if(user.Password != password) {
                 throw new Exception("Incorrect password");
            }
            var token = _jwtTokenGenerator.TokenGenerator(user.Id, user.FirstName, user.LastName);
            return new AuthResult(
               user,
                token
                );
        }

        
    }
}
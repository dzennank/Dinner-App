
using ErrorOr;

namespace BuberDinner.Domen.Common.Errors
{
    public static class ErrorsUser 
    {
        public static Error DublicateEmail = Error.Conflict(code: "User.DuplicateEmail", description: "Email is already in use"); 
        public static Error InvalidCredentials = Error.Validation(code:"User.InvalidCred", description: "Invalid Credentials");

    }
}
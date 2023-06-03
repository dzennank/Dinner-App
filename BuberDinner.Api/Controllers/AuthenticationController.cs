using BuberDinner.Contracts.Authentication;
using BuberDuinner.Application.Authentication;
using ErrorOr;
using Microsoft.AspNetCore.Mvc;
using static BuberDuinner.Application.Authentication.AuthenticationResult;

namespace BuberDinner.Api.Controllers;

    [Route("auth")]
public class AuthenticationController : ApiController
{
    private readonly IAuthenticationService _authService;

    public AuthenticationController(IAuthenticationService authService)
    {
        _authService = authService;
    }

    [HttpPost("login")]
    public IActionResult Login(LoginRequest request){
        
        ErrorOr<AuthResult> authRes = _authService.Login(request.Email, request.Password);

        return authRes.Match(
            res => Ok(res),
            errors => ErrorHandle(errors)
        );
    //    var response = new AuthResponse(
    //         authRes.user.Id,
    //         authRes.user.FirstName,
    //         authRes.user.LastName,
    //         authRes.user.Email,
    //         authRes.Token
    //     );
    //     return Ok(response);
      
    }   

     [HttpPost("register")]
    public IActionResult Register(RegisterRequest request)
    {

        ErrorOr<AuthResult> authRes = _authService.Register(
            request.FirstName, 
            request.LastName, 
            request.Email, 
            request.Password);

        return authRes.Match(
            authRes => Ok(authRes),
            errors => ErrorHandle(errors)
        );
    }

    // private static AuthResponse MapAuthResult(AuthResult authRes)
    // {
    //     return new AuthResponse(
    //         authRes.user.Id,
    //         authRes.user.FirstName,
    //         authRes.user.LastName,
    //         authRes.user.Email,
    //         authRes.Token
    //     );
    // }
}
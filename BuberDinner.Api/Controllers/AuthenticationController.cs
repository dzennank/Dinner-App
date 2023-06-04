using BuberDinner.Contracts.Authentication;
using BuberDuinner.Application.Common.Interfaces.Authentication.Commands;
using BuberDuinner.Application.Common.Interfaces.Authentication.Queries;
using ErrorOr;
using Microsoft.AspNetCore.Mvc;
using static BuberDuinner.Application.Common.Interfaces.Authentication.Common.AuthenticationResult;

namespace BuberDinner.Api.Controllers;

    [Route("auth")]
public class AuthenticationController : ApiController
{
    private readonly IAuthenticationCommandService _authService;
    private readonly IAuthenticationQueryService _queryService;

    public AuthenticationController(IAuthenticationCommandService authService, IAuthenticationQueryService queryService)
    {
        _authService = authService;
        _queryService = queryService;
    }

    [HttpPost("login")]
    public IActionResult Login(LoginRequest request){
        
        ErrorOr<AuthResult> authRes = _queryService.Login(request.Email, request.Password);

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
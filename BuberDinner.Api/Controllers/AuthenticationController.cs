using BuberDinner.Contracts.Authentication;
using BuberDuinner.Application.Authentication.Commands.Register;
using BuberDuinner.Application.Authentication.Queries.Login;

using ErrorOr;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using static BuberDuinner.Application.Common.Interfaces.Authentication.Common.AuthenticationResult;

namespace BuberDinner.Api.Controllers;

    [Route("auth")]
public class AuthenticationController : ApiController
{

    private readonly IMediator _mediator;

    public AuthenticationController(IMediator mediator)
    {
        
        _mediator = mediator;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginRequest request){

        var query = new LoginQuery(request.Email, request.Password);
        ErrorOr<AuthResult> authRes = await _mediator.Send(query);

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
    public async Task<IActionResult> Register(RegisterRequest request)
    {   
        var command = new RegisterCommand(request.FirstName, request.LastName, request.Email, request.Password);
        ErrorOr<AuthResult> authRes = await _mediator.Send(command);

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
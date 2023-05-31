using BuberDinner.Contracts.Authentication;
using BuberDuinner.Application.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace BuberDinner.Api.Controllers;

    [ApiController]
    [Route("auth")]
public class AuthenticationController : ControllerBase 
{
    private readonly IAuthenticationService _authService;

    public AuthenticationController(IAuthenticationService authService)
    {
        _authService = authService;
    }

    [HttpPost("login")]
    public IActionResult Login(LoginRequest request){
        
        var authRes = _authService.Login(request.Email, request.Password);
       var response = new AuthResponse(
            authRes.user.Id,
            authRes.user.FirstName,
            authRes.user.LastName,
            authRes.user.Email,
            authRes.Token
        );
        return Ok(response);
      
    }   

     [HttpPost("register")]
    public IActionResult Register(RegisterRequest request){
        
        var authRes = _authService.Register(request.FirstName, request.LastName, request.Email, request.Password);
        var response = new AuthResponse(
            authRes.user.Id,
            authRes.user.FirstName,
            authRes.user.LastName,
            authRes.user.Email,
            authRes.Token
        );
        return Ok(response);
    } 
}
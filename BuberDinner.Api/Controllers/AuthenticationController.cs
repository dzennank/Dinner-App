using BuberDinner.Contracts.Authentication;
using BuberDuinner.Application.Authentication.Commands.Register;
using BuberDuinner.Application.Authentication.Queries.Login;

using ErrorOr;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using static BuberDuinner.Application.Common.Interfaces.Authentication.Common.AuthenticationResult;

namespace BuberDinner.Api.Controllers;

    [Route("auth")]
public class AuthenticationController : ApiController
{

    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public AuthenticationController(IMediator mediator, IMapper mapper)
    {
        
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginRequest request){

        var query = _mapper.Map<LoginQuery>(request);
        ErrorOr<AuthResult> authRes = await _mediator.Send(query);

        return authRes.Match(
            res => Ok(_mapper.Map<AuthResponse>(res)),
            errors => ErrorHandle(errors)
        );
  
      
    }   

     [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterRequest request)
    {   
        var command = _mapper.Map<RegisterCommand>(request);
        ErrorOr<AuthResult> authRes = await _mediator.Send(command);

        return authRes.Match(
            authRes => Ok(_mapper.Map<AuthResponse>(authRes)),
            errors => ErrorHandle(errors)
        );
    }

   
}
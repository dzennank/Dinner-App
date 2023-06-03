
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace BuberDinner.Api.Controllers
{
    [Route("/error")]
    public class ErrorsController : ControllerBase
    {
        public IActionResult Error() {
            //pull exception from http request context
            Exception? exception = HttpContext.Features.Get<IExceptionHandlerFeature>().Error;
            return Problem(title: exception?.Message);
        }
    }
}
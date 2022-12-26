using BuberDinner.Application.Common.Errors;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace BuberDinner.Api.Controllers
{
    
    public class ErrorsController : ControllerBase
    {
        [HttpPost("/error")]
        public IActionResult Error()
        {
            var exception = HttpContext.Features.Get<IExceptionHandlerFeature>()?.Error;
            
            /*
            var (statusCode, message) = exception switch
            {
                DuplicateEmailException => (StatusCodes.Status409Conflict, "Email already exists."),
                 => (StatusCodes.Status500InternalServerError, "An unexpected error occured."),

            };*/
            
            return Problem(title: exception?.Message);
        }
    }
}

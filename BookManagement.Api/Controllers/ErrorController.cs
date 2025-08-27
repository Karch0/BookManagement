using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace BookManagement.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class ErrorController : ControllerBase
{
    [HttpGet]
    [ApiExplorerSettings(IgnoreApi = true)] // Hide from Swagger
    public IActionResult Error()
    {
        // Get the exception details from the context
        var exceptionHandlerPathFeature = HttpContext.Features.Get<IExceptionHandlerFeature>();
        if (exceptionHandlerPathFeature == null)
        {
            return Problem("An unexpected error occurred.");
        }

        // Log the exception (optional)
        // _logger.LogError(exceptionHandlerPathFeature.Error, "An unhandled exception occurred.");

        // Return a structured error response
        return Problem(
            title: "An error occurred while processing your request.",
            detail: exceptionHandlerPathFeature.Error.Message,
            statusCode: StatusCodes.Status500InternalServerError
        );
    }
}
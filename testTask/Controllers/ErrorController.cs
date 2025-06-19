using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace testTask.Controllers
{
    public class ErrorController : Controller
    {
        private readonly ILogger<ErrorController> _logger;

        public ErrorController(ILogger<ErrorController> logger)
        {
            _logger = logger;
        }

        [Route("/error")]
        public IActionResult Error()
        {
            var exception = HttpContext.Features.Get<IExceptionHandlerFeature>()?.Error;

            _logger.LogError(exception, "Произошла ошибка!");


            return Problem(
                title: "Внутренняя ошибка сервера!",
                statusCode: StatusCodes.Status500InternalServerError
            );
        }
    }
}

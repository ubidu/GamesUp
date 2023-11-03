using Microsoft.AspNetCore.Mvc;

namespace GamesUp.Controllers;

[ApiController]
public class ErrorsController : ControllerBase
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [Route("/error")]
    public IActionResult Error()
    {
        return Problem();
    }
}
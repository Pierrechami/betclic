using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers 
{

[ApiController]
[Route("api/[controller]")]
public class HelloWorldController : ControllerBase
{
    [HttpGet]
    public IActionResult GeHelloWorldt()
    {
        return Ok("Hello, World!");
    }
}
}

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
namespace CSP.API.Controllers;
[Authorize]
[ApiController]
[Route("api/[controller]")]
public class ServiceController : ControllerBase
{
    [HttpGet]
    public IActionResult GetServices()
    {
        var Services = new[]
        {
            new
            {
                Id=1,
                ServiceName="Income Certificate"
            },
            new
            {
                Id=2,
                ServiceName="Birth Certificate"
            }
        };
        return Ok(Services);
    }
}
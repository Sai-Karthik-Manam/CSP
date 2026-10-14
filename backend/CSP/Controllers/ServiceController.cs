using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using CSP.API.Services.Interfaces;
namespace CSP.API.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class ServiceController : ControllerBase
{
    private readonly IService _service;

    public ServiceController(IService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetServices()
    {
        var services = await _service.GetAllServicesAsync();
        return Ok(services);
    }
}
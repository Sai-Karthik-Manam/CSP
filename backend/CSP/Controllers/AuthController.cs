using Microsoft.AspNetCore.Mvc;
using CSP.API.Models.Requests;
using CSP.API.Services.Interfaces;

namespace CSP.API.Controllers;
[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IConfiguration _configuration;
    private readonly IAuthServices _authServices;
    public AuthController(IConfiguration configuration,IAuthServices authServices)
    {
        _configuration=configuration;
        _authServices=authServices;
    }
    [HttpPost("Registration")]
    public async Task<IActionResult> Registration(RegistrationModel model){
        if (model.Image == null || model.Image.Length == 0)
        {
            return BadRequest(new
            {
                message="Photo is Invalid"
            });
        }
        var path=_configuration["FileStorage:UserImages"];
        if (string.IsNullOrWhiteSpace(path))
        {
            return StatusCode(500, new
            {
                message="Profile Photo Path is not Configured"
            });
        }
        if (!Directory.Exists(path))
        {
            Directory.CreateDirectory(path);
        }

        var extension=Path.GetExtension(model.Image.FileName);
        var fileName= $"{Guid.NewGuid().ToString("N")[..10]}{extension}";
        var filePath =Path.Combine(path, fileName);
        using (var stream =new FileStream(filePath,FileMode.Create))
        {
            await model.Image.CopyToAsync(stream);
        }

            var result =await _authServices.RegistrationAsync(model,fileName,"SYSTEM");
            if (result == null)
            {
                return BadRequest(result);
            }
            return Ok(result);
    }
      [HttpPost("Login")]
    public async Task<IActionResult> Login([FromBody]LoginModel model)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(model);
        }
        var result=await _authServices.LoginAsync(model);
        return Ok(result);
    }
}

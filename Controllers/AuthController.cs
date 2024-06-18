using Microsoft.AspNetCore.Mvc;
using slavagmBackend.Helpers;

namespace slavagmBackend.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthController : ControllerBase
{
    [HttpPost("login")]
    public async Task<IActionResult> GetToken([FromBody] string password)
    {
        if (password == AuthOptions.AdminPassword)
            return Ok(JwtHelper.CreateToken());
        return Unauthorized();
    }
}
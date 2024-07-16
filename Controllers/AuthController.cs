using Microsoft.AspNetCore.Mvc;
using slavagmBackend.Helpers;
using slavagmBackend.Models;

namespace slavagmBackend.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthController : ControllerBase
{
    [HttpPost("login")]
    public async Task<IActionResult> GetToken(Auth authModel)
    {
        if (authModel.Password == AuthOptions.AdminPassword)
            return Ok(new TokenResponse { AccessToken = JwtHelper.CreateToken() });
        return Unauthorized();
    }
}
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using slavagmBackend.API.DTOs.Auth;
using slavagmBackend.Core.Services;
using slavagmBackend.Services;
using slavagmBackend.Services.Helpers;

namespace slavagmBackend.API.Controllers;

[ApiController]
[Route("api/auth")]
public class AuthController : Controller
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [AllowAnonymous]
    [HttpPost("login")]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> Login([FromBody] LoginRequestDto data)
    {
        var token = await _authService.Login(data.Password);
        return Ok(new { token = token });
    }
}
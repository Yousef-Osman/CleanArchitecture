using CleanArchitecture.Application.DTOs.Auth;
using CleanArchitecture.Application.Interfaces.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.Api.Controllers;
[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterRequestDto input)
    {
        var result = await _authService.RegisterAsync(input);

        if (!result.Success) 
            return BadRequest(result.Errors);

        return Ok(result);
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginRequestDto input)
    {
        var result = await _authService.LoginAsync(input);

        if (!result.Success) 
            return Unauthorized(result.Errors);

        return Ok(result);
    }

    //[HttpPost("refresh-token")]
    //public async Task<IActionResult> RefreshToken(RefreshTokenRequestDto input)
    //{
    //    var result = await _authService.RefreshTokenAsync(input);
    //    if (!result.Success) return Unauthorized(result.Errors);
    //    return Ok(result.Token);
    //}
}

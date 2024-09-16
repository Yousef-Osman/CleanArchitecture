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

    [HttpPost("Register")]
    public async Task<IActionResult> Register(RegisterRequest input)
    {
        var result = await _authService.RegisterAsync(input);

        if (!result.Success) 
            return BadRequest(result.Errors);

        return Ok(result);
    }

    [HttpPost("Login")]
    public async Task<IActionResult> Login(LoginRequest input)
    {
        var result = await _authService.LoginAsync(input);

        if (!result.Success) 
            return Unauthorized(result.Errors);

        return Ok(result);
    }
}

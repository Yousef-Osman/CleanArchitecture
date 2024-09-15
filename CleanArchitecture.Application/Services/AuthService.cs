using CleanArchitecture.Application.DTOs.Auth;
using CleanArchitecture.Application.Interfaces.Identity;

namespace CleanArchitecture.Application.Services;
internal class AuthService: IAuthService
{
    private readonly IUserService _userService;
    private readonly ITokenService _tokenService;

    public AuthService(IUserService userService, ITokenService tokenService)
    {
        _userService = userService;
        _tokenService = tokenService;
    }

    public async Task<AuthResultDto> RegisterAsync(RegisterRequestDto input)
    {
        var user = new UserDto
        {
            UserName = input.Email,
            Email = input.Email
        };

        var result = await _userService.CreateUserAsync(user, input.Password);

        if (!result.Succeeded)
        {
            return new AuthResultDto
            {
                Success = false,
                Errors = result.Errors?.Select(e => e.Description)
            };
        }

        var token = _tokenService.GenerateToken(user);

        return new AuthResultDto { Success = true, Token = token };
    }

    public async Task<AuthResultDto> LoginAsync(LoginRequestDto input)
    {
        var user = await _userService.FindByEmailAsync(input.Email);

        if (user == null || !await _userService.CheckPasswordAsync(user, input.Password))
        {
            return new AuthResultDto
            {
                Success = false,
                Errors = new[] { "Invalid credentials" }
            };
        }

        var token = _tokenService.GenerateToken(user);

        return new AuthResultDto { Success = true, Token = token };
    }
}

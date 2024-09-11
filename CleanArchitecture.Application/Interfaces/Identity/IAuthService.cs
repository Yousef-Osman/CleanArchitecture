using CleanArchitecture.Application.DTOs.Auth;
namespace CleanArchitecture.Application.Interfaces.Identity;
public interface IAuthService
{
    Task<AuthResultDto> RegisterAsync(RegisterRequestDto model);
    Task<AuthResultDto> LoginAsync(LoginRequestDto model);
    //Task<AuthResultDto> RefreshTokenAsync(RefreshTokenRequestDto model);
}

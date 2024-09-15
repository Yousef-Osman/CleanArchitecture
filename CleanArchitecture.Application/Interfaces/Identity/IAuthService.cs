using CleanArchitecture.Application.DTOs.Auth;
namespace CleanArchitecture.Application.Interfaces.Identity;
public interface IAuthService
{
    Task<AuthResult> RegisterAsync(RegisterRequest model);
    Task<AuthResult> LoginAsync(LoginRequest model);
}

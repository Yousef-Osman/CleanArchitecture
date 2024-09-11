using CleanArchitecture.Application.DTOs.Auth;

namespace CleanArchitecture.Application.Interfaces.Identity;
public interface ITokenService
{
    string GenerateToken(UserDto user);
    Task<string> GenerateRefreshTokenAsync(UserDto user);
    Task<bool> ValidateRefreshTokenAsync(string token, UserDto user);
}

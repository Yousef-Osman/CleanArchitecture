using CleanArchitecture.Application.DTOs.Auth;

namespace CleanArchitecture.Application.Interfaces.Identity;
public interface IUserService
{
    Task<UserDto?> FindByEmailAsync(string email);
    Task<bool> CheckPasswordAsync(UserDto userDto, string password);
    Task<IdentityResultDto> CreateUserAsync(UserDto userDto, string password);
}

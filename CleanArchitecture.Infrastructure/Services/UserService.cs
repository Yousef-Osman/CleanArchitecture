using CleanArchitecture.Application.DTOs.Auth;
using CleanArchitecture.Application.Interfaces.Identity;
using CleanArchitecture.Infrastructure.Data.Models;
using CleanArchitecture.Infrastructure.Mappers;
using Microsoft.AspNetCore.Identity;

namespace CleanArchitecture.Infrastructure.Services;
public class UserService : IUserService
{
    private readonly UserManager<AppUser> _userManager;

    public UserService(UserManager<AppUser> userManager)
    {
        _userManager = userManager;
    }

    public async Task<UserDto?> FindByEmailAsync(string email)
    {
        var user = await _userManager.FindByEmailAsync(email);
        return user?.ToUserDto();
    }

    public async Task<bool> CheckPasswordAsync(UserDto userDto, string password)
    {
        var user = userDto.ToAppUser();
        return await _userManager.CheckPasswordAsync(user, password);
    }

    public async Task<IdentityResultDto> CreateUserAsync(UserDto userDto, string password)
    {
        var user = userDto.ToAppUser();
        var result = await _userManager.CreateAsync(user, password);
        return result.ToIdentityResultDto();
    }
}

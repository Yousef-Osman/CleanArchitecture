using CleanArchitecture.Application.DTOs.Auth;
using CleanArchitecture.Infrastructure.Data.Models;

namespace CleanArchitecture.Infrastructure.Mappers;
public static class UserMappers
{
    public static UserDto ToUserDto(this AppUser user)
    {
        return new UserDto { 
            Id = user.Id,
            UserName = user.UserName,
            Email = user.Email,
            EmailConfirmed = user.EmailConfirmed,
            PhoneNumber = user.PhoneNumber,
            PhoneNumberConfirmed = user.PhoneNumberConfirmed,
            PasswordHash = user.PasswordHash,
        };
    }

    public static AppUser ToAppUser(this UserDto user)
    {
        return new AppUser
        {
            Id = user.Id,
            UserName = user.UserName,
            Email = user.Email,
            EmailConfirmed = user.EmailConfirmed,
            PhoneNumber = user.PhoneNumber,
            PhoneNumberConfirmed = user.PhoneNumberConfirmed,
            PasswordHash = user.PasswordHash,
        };
    }
}

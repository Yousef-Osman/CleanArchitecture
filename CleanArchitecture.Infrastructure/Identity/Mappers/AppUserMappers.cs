using CleanArchitecture.Application.DTOs.Auth;
using CleanArchitecture.Infrastructure.Identity.Models;

namespace CleanArchitecture.Infrastructure.Identity.Mappers;
public static class AppUserMappers
{
    public static UserDto ToUserDto(this AppUser user)
    {
        return new UserDto
        {
            Id = user.Id,
            UserName = user.UserName,
            FirstName = user.FirstName,
            LastName = user.LastName,
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
            FirstName = user.FirstName,
            LastName = user.LastName,
            Email = user.Email,
            EmailConfirmed = user.EmailConfirmed,
            PhoneNumber = user.PhoneNumber,
            PhoneNumberConfirmed = user.PhoneNumberConfirmed,
            PasswordHash = user.PasswordHash,
        };
    }
}

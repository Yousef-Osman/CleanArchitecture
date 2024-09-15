using System.ComponentModel.DataAnnotations;

namespace CleanArchitecture.Application.DTOs.Auth;
public class RegisterRequest
{
    [EmailAddress]
    public required string Email { get; set; }

    public required string UserName { get; set; }

    public required string Password { get; set; }
}

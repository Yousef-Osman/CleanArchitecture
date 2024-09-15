using System.ComponentModel.DataAnnotations;

namespace CleanArchitecture.Application.DTOs.Auth;
public class LoginRequest
{
    [EmailAddress]
    public required string Email { get; set; }

    public required string Password { get; set; }
}

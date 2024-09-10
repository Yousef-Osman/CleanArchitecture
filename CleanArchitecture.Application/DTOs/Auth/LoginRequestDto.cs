using System.ComponentModel.DataAnnotations;

namespace CleanArchitecture.Application.DTOs.Auth;
public class LoginRequestDto
{
    [Required, EmailAddress]
    public required string Email { get; set; }

    [Required]
    public required string Password { get; set; }
}

using System.ComponentModel.DataAnnotations;

namespace CleanArchitecture.Application.DTOs.Auth;
public class RegisterRequestDto
{
    [Required, EmailAddress]
    public required string Email { get; set; }

    [Required]
    public required string Password { get; set; }

    [Compare(nameof(Password))]
    public required string ConfirmPassword { get; set; }
}

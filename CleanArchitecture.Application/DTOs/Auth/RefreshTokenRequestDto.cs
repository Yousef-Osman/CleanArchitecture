namespace CleanArchitecture.Application.DTOs.Auth;
public class RefreshTokenRequestDto
{
    public required string UserId { get; set; }
    public required string RefreshToken { get; set; }
}

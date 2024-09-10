namespace CleanArchitecture.Application.DTOs.Auth;
public class UserDto
{
    public UserDto()
    {
        Id = Guid.NewGuid().ToString();
    }

    public string Id { get; set; } = default!;
    public string? UserName { get; set; }
    public string? Email { get; set; }
    public bool EmailConfirmed { get; set; }
    public string? PhoneNumber { get; set; }
    public bool PhoneNumberConfirmed { get; set; }
    public string? PasswordHash { get; set; }
}

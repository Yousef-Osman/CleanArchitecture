namespace CleanArchitecture.Application.DTOs.Auth;
public class IdentityResultDto
{
    public bool Succeeded { get; set; }
    public IEnumerable<IdentityErrorDto>? Errors { get; set; }
}

public class IdentityErrorDto
{
    public string Code { get; set; } = default!;
    public string Description { get; set; } = default!;
}

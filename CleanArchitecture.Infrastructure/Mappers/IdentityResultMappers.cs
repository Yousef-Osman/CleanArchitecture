using CleanArchitecture.Application.DTOs.Auth;
using Microsoft.AspNetCore.Identity;

namespace CleanArchitecture.Infrastructure.Mappers;
public static class IdentityResultMappers
{
    public static IdentityResultDto ToIdentityResultDto(this IdentityResult result)
    {
        return new IdentityResultDto
        {
            Succeeded = result.Succeeded,
            Errors = result.Errors?.Select(x => x.ToIdentityResultDto())
        };
    }
    
    public static IdentityErrorDto ToIdentityResultDto(this IdentityError error)
    {
        return new IdentityErrorDto
        {
            Code = error.Code,
            Description = error.Description,
        };
    }
}

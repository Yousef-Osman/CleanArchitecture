using CleanArchitecture.Domain.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace CleanArchitecture.Infrastructure.Data.Models;
public class AppUser: IdentityUser, IUser
{
}

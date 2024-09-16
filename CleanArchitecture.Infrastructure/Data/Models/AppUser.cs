using CleanArchitecture.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace CleanArchitecture.Infrastructure.Data.Models;
public class AppUser: IdentityUser
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public List<Product>? Products { get; set; }
}

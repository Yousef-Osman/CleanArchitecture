using CleanArchitecture.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace CleanArchitecture.Infrastructure.Data.Models;
public class AppUser: IdentityUser
{
    public List<Product>? Products { get; set; }
}

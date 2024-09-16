using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace CleanArchitecture.Infrastructure.Data;
public class AppDbContext: IdentityDbContext<AppUser>
{
    public DbSet<Product> Products { get; set; }
    public DbSet<Brand> Brands { get; set; }
    public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}

using CleanArchitecture.Application.Interfaces.Persistence;
using CleanArchitecture.Infrastructure.Data;
using CleanArchitecture.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitecture.Infrastructure;
public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration config)
    {
        string defaultConnectionString = config.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string not found.");

        services.AddDbContext<AppDbContext>(options => options.UseSqlServer(defaultConnectionString));

        services.AddScoped(typeof(IReadRepository<,>), typeof(GenericRepository<,>));
        services.AddScoped(typeof(IRepository<,>), typeof(GenericRepository<,>));

        return services;
    }
}

using CleanArchitecture.Application.Interfaces.Identity;
using CleanArchitecture.Application.Services;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace CleanArchitecture.Application;
public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(options =>
        {
            //options.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly);
            options.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
        });

        services.AddScoped<IAuthService, AuthService>();

        return services;
    }
}

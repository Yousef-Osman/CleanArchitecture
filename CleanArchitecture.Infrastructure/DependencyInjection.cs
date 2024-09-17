using CleanArchitecture.Application.Interfaces.Identity;
using CleanArchitecture.Application.Interfaces.Persistence;
using CleanArchitecture.Infrastructure.Common;
using CleanArchitecture.Infrastructure.Data;
using CleanArchitecture.Infrastructure.Data.Repositories;
using CleanArchitecture.Infrastructure.Identity;
using CleanArchitecture.Infrastructure.Identity.Models;
using CleanArchitecture.Infrastructure.Identity.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace CleanArchitecture.Infrastructure;
public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration config)
    {
        string defaultConnectionString = config.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Default connection string not found.");
        string identityConnectionString = config.GetConnectionString("IdentityConnection") ?? throw new InvalidOperationException("Identity connection string not found.");

        services.AddDbContext<AppDbContext>(options => options.UseSqlServer(defaultConnectionString));
        services.AddDbContext<AppIdentityDbContext>(options => options.UseSqlServer(identityConnectionString));

        services.AddIdentityCore<AppUser>()
            .AddEntityFrameworkStores<AppIdentityDbContext>()
            .AddDefaultTokenProviders();

        services.AddAuthentication(config);

        services.AddAuthentication().AddBearerToken(IdentityConstants.BearerScheme);
        services.AddAuthorizationBuilder();

        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped(typeof(IReadRepository<,>), typeof(GenericRepository<,>));
        services.AddScoped(typeof(IRepository<,>), typeof(GenericRepository<,>));
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        return services;
    }

    private static IServiceCollection AddAuthentication(this IServiceCollection services, IConfiguration config)
    {
        services.Configure<JwtSettings>(config.GetSection(nameof(JwtSettings)));

        var key = Encoding.ASCII.GetBytes(config["JwtSettings:Key"] ?? string.Empty);

        services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        })
        .AddJwtBearer(options =>
        {
            options.RequireHttpsMetadata = false;
            options.SaveToken = true;
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidIssuer = config["JwtSettings:Issuer"],
                ValidAudience = config["JwtSettings:Audience"],
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key)
            };
        });

        return services;
    }
}

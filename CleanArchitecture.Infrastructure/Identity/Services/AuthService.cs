using CleanArchitecture.Application.DTOs.Auth;
using CleanArchitecture.Application.Interfaces.Identity;
using CleanArchitecture.Application.Interfaces.Persistence;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Infrastructure.Common;
using CleanArchitecture.Infrastructure.Identity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CleanArchitecture.Infrastructure.Identity.Services;
public class AuthService : IAuthService
{
    private readonly JwtSettings _jwtSettings;
    private readonly UserManager<AppUser> _userManager;
    private readonly IRepository<User, long> _userRepo;
    private readonly IUnitOfWork _unitOfWork;

    public AuthService(UserManager<AppUser> userManager,
        IOptions<JwtSettings> jwtSettings,
        IRepository<User, long> userRepo,
        IUnitOfWork unitOfWork)
    {
        _jwtSettings = jwtSettings.Value;
        _userManager = userManager;
        _userRepo = userRepo;
        _unitOfWork = unitOfWork;
    }

    public async Task<AuthResult> RegisterAsync(RegisterRequest input)
    {
        var oldUser = await _userManager.FindByEmailAsync(input.Email);

        if (oldUser != null)
        {
            return new AuthResult
            {
                Success = false,
                Errors = new[] { "Email is already taken." }
            };
        }

        var user = new AppUser
        {
            UserName = input.UserName,
            Email = input.Email
        };

        var result = await _userManager.CreateAsync(user, input.Password);

        if (!result.Succeeded)
        {
            return new AuthResult
            {
                Success = false,
                Errors = result.Errors?.Select(e => e.Description)
            };
        }

        await AddUserToApplicationDB(input.Email);

        var token = GenerateToken(user);

        return new AuthResult { Success = true, Token = token };
    }

    private async Task AddUserToApplicationDB(string email)
    {
        var identityUser = await _userManager.FindByEmailAsync(email);

        if (identityUser == null)
            return;

        var user = new User { IdentityUserId = identityUser.Id };

        _userRepo.Add(user);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task<AuthResult> LoginAsync(LoginRequest input)
    {
        var user = await _userManager.FindByEmailAsync(input.Email);

        if (user == null)
            user = await _userManager.FindByNameAsync(input.Email);

        if (user == null || !await _userManager.CheckPasswordAsync(user, input.Password))
        {
            return new AuthResult
            {
                Success = false,
                Errors = new[] { "Invalid Username or Password" }
            };
        }

        var token = GenerateToken(user);

        return new AuthResult { Success = true, Token = token };
    }

    public string GenerateToken(AppUser user)
    {
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Key));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, user.UserName!),
            new Claim(JwtRegisteredClaimNames.Email,user.Email!),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim(ClaimTypes.NameIdentifier, user.Id),
        };

        var token = new JwtSecurityToken(
            issuer: _jwtSettings.Issuer,
            audience: _jwtSettings.Audience,
            claims: claims,
            expires: DateTime.UtcNow.AddMinutes(_jwtSettings.ExpiresInMinutes),
            signingCredentials: creds);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
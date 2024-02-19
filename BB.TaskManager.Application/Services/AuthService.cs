using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using BB.TaskManager.Application.Interfaces;
using BB.TaskManager.Domain.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace BB.TaskManager.Application.Services;

public class AuthService : IAuthService
{
    private readonly UserManager<IdentityUser> _userManager;
    private readonly IUserRepository _userRepository;
    private readonly IConfiguration _configuration;

    public AuthService(UserManager<IdentityUser> userManager, IUserRepository userRepository, IConfiguration configuration)
    {
        _userManager = userManager;
        _userRepository = userRepository;
        _configuration = configuration;
    }
    
    public async Task<string> AuthenticateAsync(string email, string password)
    {
        var user = await _userManager.FindByEmailAsync(email);
        
        if (user != null && await _userManager.CheckPasswordAsync(user, password))
        {
            var token = GenerateJwtToken(user);
            return token;
        }

        return null;
    }

    public async Task<string> CreateAsync(string username, string email, string password)
    {
        var existingUser = await _userManager.FindByEmailAsync(email);

        if (existingUser != null)
            return null;

        var newUser = new IdentityUser()
        {
            Email = email,
            UserName = username,
        };

        var result = await _userManager.CreateAsync(newUser, password);

        if (result.Succeeded)
        {
            await _userRepository.CreateUserAsync(Guid.Parse(newUser.Id), newUser.UserName, newUser.Email);
            
            var token = GenerateJwtToken(newUser);
            return token;
        }
        
        return null;
    }

    public async Task<bool> UpdateAsync(Guid id,string email, string username)
    {

        return await _userRepository.UpdateUserAsync(id, email, username);
    }

    private string GenerateJwtToken(IdentityUser user)
    {
        var claims = new List<Claim>
        {
            new (ClaimTypes.NameIdentifier, user.Id.ToString()),
            new (ClaimTypes.Name, user.UserName),
            // Добавьте дополнительные утверждения, если необходимо
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:SecretKey"]));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        var expires = DateTime.Now.AddHours(Convert.ToDouble(_configuration["Jwt:ExpireHours"]));

        var token = new JwtSecurityToken(
            _configuration["Jwt:Issuer"],
            _configuration["Jwt:Audience"],
            claims,
            expires: expires,
            signingCredentials: creds
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
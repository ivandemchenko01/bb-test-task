using BB.TaskManager.Domain.Interfaces;
using BB.TaskManager.Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BB.TaskManager.Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
    private readonly ApplicationDbContext _context;
    private readonly UserManager<IdentityUser> _userManager;

    public UserRepository(ApplicationDbContext context, UserManager<IdentityUser> userManager)
    {
        _context = context;
        _userManager = userManager;
    }
        
    public async Task<User> GetByEmailAsync(string email)
    {
        var user = await _context.ApplicationUsers.FirstOrDefaultAsync(x => x.Email == email);

        if (user is null)
            throw new Exception($"User with email {email} was not found");
        
        return user;
    }

    public async Task<Guid> CreateUserAsync(Guid id, string username, string email)
    {
        var user = new User
        {
            Id = id,
            Email = email,
            Username = username,
            TaskList = new List<TaskList>()
        };

        await _context.ApplicationUsers.AddAsync(user);
        await _context.SaveChangesAsync();

        return user.Id;
    }

    public async Task<bool> UpdateUserAsync(Guid id, string email, string username)
    {
        var user = await _context.ApplicationUsers.FindAsync(id);
        
        if (user is null)
            throw new Exception($"User with id {id} was not found.");
        
        var identityUser = await _userManager.FindByIdAsync(id.ToString());
        if (identityUser is null)
            throw new Exception($"Identity user with id {id} was not found");

        identityUser.Email = email;
        identityUser.UserName = username;
        
        var result = await _userManager.UpdateAsync(identityUser);
        if (!result.Succeeded)
            throw new Exception($"Cannot update user with email : {email}, and username : {username}"); 
                
        
        user.Email = email;
        user.Username = username;
        
        await _context.SaveChangesAsync();

        return true;
    }
}
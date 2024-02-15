using BB.TaskManager.Domain.Interfaces;
using BB.TaskManager.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace BB.TaskManager.Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
    private readonly ApplicationDbContext _context;

    public UserRepository(ApplicationDbContext context)
    {
        _context = context;
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
        var user = await _context.ApplicationUsers.FirstOrDefaultAsync(x => x.Id == id);

        if (user is null)
            throw new Exception($"User with id {id} was not found.");
        
        user.Email = email;
        user.Username = username;

        await _context.SaveChangesAsync();

        return true;
    }
}
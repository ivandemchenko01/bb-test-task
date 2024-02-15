using BB.TaskManager.Domain.Models;

namespace BB.TaskManager.Domain.Interfaces;

public interface IUserRepository
{
    Task<User> GetByEmailAsync(string email);
    Task<Guid> CreateUserAsync(Guid id, string username, string email);
    Task<bool> UpdateUserAsync(Guid id, string username, string title);
}
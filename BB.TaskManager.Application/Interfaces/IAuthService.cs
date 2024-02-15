using BB.TaskManager.Domain.Models;

namespace BB.TaskManager.Application.Interfaces;

public interface IAuthService
{
    Task<string> AuthenticateAsync(string email, string password);
    Task<string> CreateAsync(string email, string username, string password);
}
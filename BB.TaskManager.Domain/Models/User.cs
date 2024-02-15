namespace BB.TaskManager.Domain.Models;

public class User
{
    public Guid Id { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }

    public List<TaskList> TaskList { get; set; }
}
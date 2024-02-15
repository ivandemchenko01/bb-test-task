namespace BB.TaskManager.Domain.Models;

public class TaskList
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public ICollection<Task> Tasks { get; set; } = new List<Task>();
    public User User { get; set; }
    public Guid UserId { get; set; }
}
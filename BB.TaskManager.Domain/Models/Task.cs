namespace BB.TaskManager.Domain.Models;

public class Task
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime CreationDate { get; set; }
    public BB.TaskManager.Contracts.Enumerations.TaskStatus Status { get; set; }
    public List<TaskHistory> History { get; set; } = new();
    public Guid TaskListId { get; set; }
    public TaskList TaskList { get; set; }
}
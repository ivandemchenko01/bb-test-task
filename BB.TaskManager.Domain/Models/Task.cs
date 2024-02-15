namespace BB.TaskManager.Domain.Models;

public class Task
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime CreationDate { get; set; }
    public TaskStatus Status { get; set; }
    
    public Guid TaskListId { get; set; }
    public TaskList TaskList { get; set; }
}
namespace BB.TaskManager.Contracts.Models;

public class UpdateTaskModel
{
    public Guid TaskId { get; set; }
    public Guid UserId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public BB.TaskManager.Contracts.Enumerations.TaskStatus Status { get; set; }
}
namespace BB.TaskManager.Contracts.Models;

public class ChangeTaskStatusModel
{
    public Guid UserId { get; set; }
    public Guid TaskId { get; set; }
    public BB.TaskManager.Contracts.Enumerations.TaskStatus Status { get; set; }
}
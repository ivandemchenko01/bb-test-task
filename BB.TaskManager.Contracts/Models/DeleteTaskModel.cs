namespace BB.TaskManager.Contracts.Models;

public class DeleteTaskModel
{
    public Guid UserId { get; set; }
    public Guid TaskId { get; set; }
}
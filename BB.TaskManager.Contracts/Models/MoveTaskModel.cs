namespace BB.TaskManager.Contracts.Models;

public class MoveTaskModel
{
    public Guid UserId { get; set; }
    public Guid TaskId { get; set; }
    public Guid TaskListDestinationId { get; set; }
}
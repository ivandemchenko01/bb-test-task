namespace BB.TaskManager.Contracts.Models;

public class DeleteTaskListModel
{
    public Guid UserId { get; set; }
    public Guid TaskListId { get; set; }
}
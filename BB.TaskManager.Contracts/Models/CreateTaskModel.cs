namespace BB.TaskManager.Contracts.Models;

public class CreateTaskModel
{
    public Guid UserId { get; set; }
    public Guid TaskListId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
}
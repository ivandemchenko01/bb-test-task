namespace BB.TaskManager.Application.ViewModels.DataTransferObjects;

public abstract class TaskDto
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public TaskStatus Status { get; set; }
}
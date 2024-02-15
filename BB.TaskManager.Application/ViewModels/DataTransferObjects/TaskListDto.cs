namespace BB.TaskManager.Application.ViewModels.DataTransferObjects;

public class TaskListDto
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public List<TaskDto> Tasks { get; set; }
}
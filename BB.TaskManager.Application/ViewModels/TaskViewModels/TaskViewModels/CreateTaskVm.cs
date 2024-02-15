namespace BB.TaskManager.Application.ViewModels.TaskViewModels.TaskViewModels;

public class CreateTaskVm
{
    public Guid TaskListId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
}
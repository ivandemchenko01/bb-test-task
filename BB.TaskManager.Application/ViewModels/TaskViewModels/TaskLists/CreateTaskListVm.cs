namespace BB.TaskManager.Application.ViewModels;

public class CreateTaskListVm
{
    public Guid UserId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
}
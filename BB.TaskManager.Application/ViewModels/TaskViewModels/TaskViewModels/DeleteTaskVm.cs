namespace BB.TaskManager.Application.ViewModels.TaskViewModels.TaskViewModels;

public class DeleteTaskVm
{
    public Guid Id { get; set; }
}

public class MoveTaskVm
{
    public Guid TaskId { get; set; }
    public Guid TaskListDestinationId { get; set; }
}
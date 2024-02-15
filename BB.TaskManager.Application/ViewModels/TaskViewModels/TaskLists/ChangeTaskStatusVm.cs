using TaskStatus = BB.TaskManager.Contracts.Enumerations.TaskStatus;

namespace BB.TaskManager.Application.ViewModels;

public class ChangeTaskStatusVm
{
    public Guid TaskId { get; set; }
    public TaskStatus Status { get; set; }
}
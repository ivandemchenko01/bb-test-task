using BB.TaskManager.Contracts.Models;
using BB.TaskManager.Domain.Models;

namespace BB.TaskManager.Application.Interfaces;

public interface ITaskService
{
    Task<Guid> CreateTaskListAsync(CreateTaskListModel model);
    Task<Guid> UpdateTaskListAsync(UpdateTaskListModel model);
    Task<bool> DeleteTaskListAsync(DeleteTaskListModel model);
    
    Task<Guid> CreateTaskAsync(CreateTaskModel model);
    Task<Guid> UpdateTaskAsync(UpdateTaskModel model);
    Task<bool> DeleteTaskAsync(DeleteTaskModel model);
    Task<List<TaskList>> GetTaskListsAsync(Guid userId, GetTaskListFilter filter);
    Task<bool> MoveTaskAsync(MoveTaskModel model);
    Task<bool> ChangeTaskStatusAsync(ChangeTaskStatusModel requestModel);
}
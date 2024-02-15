using BB.TaskManager.Contracts.Models;
using BB.TaskManager.Domain.Models;
using Task = BB.TaskManager.Domain.Models.Task;

namespace BB.TaskManager.Domain.Interfaces;

public interface ITaskRepository
{
    Task<Guid> CreateTaskAsync(CreateTaskModel model);
    Task<Guid> UpdateTaskAsync(UpdateTaskModel model);
    Task<bool> DeleteTaskAsync(DeleteTaskModel model);
    
    Task<List<TaskList>> GetTaskListsAsync(Guid userId, GetTaskListFilter filter);
    
    Task<Guid> CreateTaskListAsync(CreateTaskListModel model);
    Task<bool> UpdateTaskListAsync(UpdateTaskListModel model);
    Task<bool> DeleteTaskListAsync(DeleteTaskListModel model);
    Task<bool> MoveTaskAsync(MoveTaskModel model);
}
using BB.TaskManager.Application.ViewModels;
using BB.TaskManager.Application.ViewModels.DataTransferObjects;
using BB.TaskManager.Application.ViewModels.TaskViewModels.TaskViewModels;
using BB.TaskManager.Contracts.Models;
using BB.TaskManager.Domain.Models;
using Task = BB.TaskManager.Domain.Models.Task;

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
}
using BB.TaskManager.Application.Interfaces;
using BB.TaskManager.Contracts.Models;
using BB.TaskManager.Domain.Interfaces;
using BB.TaskManager.Domain.Models;
using Task = BB.TaskManager.Domain.Models.Task;

namespace BB.TaskManager.Application.Services;

public class TaskService : ITaskService
{
    private readonly ITaskRepository _taskRepository;
    
    public TaskService(ITaskRepository taskRepository)
    {
        _taskRepository = taskRepository;
    }
    public async Task<Guid> CreateTaskListAsync(CreateTaskListModel model)
    {
         return await _taskRepository.CreateTaskListAsync(model);
    }

    public async Task<Guid> UpdateTaskListAsync(UpdateTaskListModel model)
    {
        await _taskRepository.UpdateTaskListAsync(model);
        return model.TaskListId;
    }

    public async Task<bool> DeleteTaskListAsync(DeleteTaskListModel model)
    {
        return await _taskRepository.DeleteTaskListAsync(model);
    }

    public async Task<Guid> CreateTaskAsync(CreateTaskModel model)
    {
        return await _taskRepository.CreateTaskAsync(model);
    }

    public async Task<Guid> UpdateTaskAsync(UpdateTaskModel model)
    {
        return await _taskRepository.UpdateTaskAsync(model);
    }

    public async Task<bool> DeleteTaskAsync(DeleteTaskModel model)
    {
        return await _taskRepository.DeleteTaskAsync(model);
    }

    public async Task<List<TaskList>> GetTaskListsAsync(Guid userId, GetTaskListFilter filter)
    {
        return await _taskRepository.GetTaskListsAsync(userId, filter);
    }

    public async Task<bool> MoveTaskAsync(MoveTaskModel model)
    {
        return await _taskRepository.MoveTaskAsync(model);
    }
}
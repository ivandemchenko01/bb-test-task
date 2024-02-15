using BB.TaskManager.Contracts.Models;
using BB.TaskManager.Domain.Interfaces;
using BB.TaskManager.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Task = BB.TaskManager.Domain.Models.Task;

namespace BB.TaskManager.Infrastructure.Repositories;

public class TaskRepository : ITaskRepository
{
    private readonly ApplicationDbContext _context;

    public TaskRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    

    public async Task<Guid> CreateTaskListAsync(Guid userId, string title, string description)
    {
        var user = await _context.ApplicationUsers.FirstOrDefaultAsync(u => u.Id == userId);
        if (user is null)
            throw new Exception($"User with id {userId} was not found.");
        
        var taskList = new TaskList
        {
            Id = Guid.NewGuid(),
            Title = title,
            Description = description,
            Tasks = new List<Task>(),
            UserId = userId
        };

        await _context.TaskLists.AddAsync(taskList);
        await _context.SaveChangesAsync();

        return taskList.Id;
    }

    public async Task<List<TaskList>> GetTaskListsAsync(Guid userId)
    { 
        var result = await _context.TaskLists
            .Include(x=>x.Tasks)
            .Where(x => x.UserId == userId)
            .ToListAsync();
        return result;
    }
       
    
    public async Task<Guid> CreateTaskAsync(CreateTaskModel model)
    {
        var taskList =
            await _context.TaskLists.FirstOrDefaultAsync(tl => tl.Id == model.TaskListId && tl.UserId == model.UserId);

        if (taskList is null)
            throw new Exception($"Task list with {model.TaskListId} was not found");

        var task = new Task()
        {
            Id = Guid.NewGuid(),
            Title = model.Title,
            Description = model.Description,
            TaskListId = model.TaskListId,
            History = new ()
            {
                new TaskHistory
                {
                    Id = Guid.NewGuid(),
                    Status = BB.TaskManager.Contracts.Enumerations.TaskStatus.Waiting,
                    Date = DateTime.Now
                }
            },
            Status = BB.TaskManager.Contracts.Enumerations.TaskStatus.Waiting
        };
        
        await _context.Tasks.AddAsync(task);
        await _context.SaveChangesAsync();
        return task.Id;
    }
    
    public async Task<Guid> UpdateTaskAsync(UpdateTaskModel model)
    {
        var task = await _context.Tasks
            .Include(x=>x.TaskList)
            .FirstOrDefaultAsync(t => t.Id == model.TaskId);
        
        if (task is null)
            throw new Exception($"Task with id {model.TaskId} was not found.");

        if (task.TaskList.UserId != model.UserId)
            throw new Exception($"Task with id {model.TaskId} created not by user {model.UserId}");

        task.Title = model.Title;
        task.Description = model.Description;
        task.Status = model.Status;

        _context.Tasks.Update(task);
        await _context.SaveChangesAsync();

        return task.Id;
    }

    public async Task<bool> DeleteTaskAsync(DeleteTaskModel model)
    {
        var task = await _context.Tasks.Include(x => x.TaskList)
            .FirstOrDefaultAsync(x => x.Id == model.TaskId && x.TaskList.UserId == model.UserId);

        if (task is null)
            throw new Exception($"Task with id {model.TaskId} was not found in user database.");

        _context.Tasks.Remove(task);
        await _context.SaveChangesAsync();
        
        return true;
    }

    public async Task<List<TaskList>> GetTaskListsAsync(Guid userId, GetTaskListFilter filter)
    {
        var taskLists = await _context.TaskLists
            .Include(x=>x.Tasks)
            .ThenInclude(x=>x.History)
            .Where(x =>
                x.UserId == userId &&
                x.Title.ToLower().Contains(filter.TitleQuery.ToLower()) &&
                x.Description.ToLower().Contains(filter.DescriptionQuery.ToLower()))
            .Skip((filter.Page - 1) * 10)
            .Take(10)
            .ToListAsync();

        return taskLists;
    }

    public async Task<Guid> CreateTaskListAsync(CreateTaskListModel model)
    {
        var user = await _context.ApplicationUsers.FirstOrDefaultAsync(u => u.Id == model.UserId);
        if (user is null)
            throw new Exception($"User with id {model.UserId} was not found.");
        
        var taskList = new TaskList
        {
            Id = Guid.NewGuid(),
            Title = model.Title,
            Description = model.Description,
            Tasks = new List<Task>(),
            UserId = model.UserId
        };

        await _context.TaskLists.AddAsync(taskList);
        
        await _context.SaveChangesAsync();

        return taskList.Id;
    }

    public async Task<bool> UpdateTaskListAsync(UpdateTaskListModel model)
    {
        var taskList = await _context.TaskLists
            .FirstOrDefaultAsync(t => t.Id == model.TaskListId && t.UserId == model.UserId);
        
        if (taskList is null)
            throw new Exception($"Task list with id {model.TaskListId} was not found.");

        taskList.Title = model.Title;
        taskList.Description = model.Description;
        
        _context.TaskLists.Update(taskList);
        await _context.SaveChangesAsync();

        return true;
    }

    public async Task<bool> DeleteTaskListAsync(DeleteTaskListModel model)
    {
        var taskList = await _context.TaskLists
            .Include(x=>x.Tasks)
            .FirstOrDefaultAsync(x => x.Id == model.TaskListId && x.UserId == model.UserId);

        if (taskList is null)
            throw new Exception($"Task with id {model.TaskListId} was not found in user database.");

        if (taskList.Tasks.Count > 0)
            throw new Exception($"Cannot delete not empty list");
                
        _context.TaskLists.Remove(taskList);
        await _context.SaveChangesAsync();
        
        return true;
    }

    public async Task<bool> MoveTaskAsync(MoveTaskModel model)
    {
        var task = await _context
            .Tasks
            .Include(x => x.TaskList)
            .FirstOrDefaultAsync(x => x.Id == model.TaskId && x.TaskList.UserId == model.UserId);
        
        if (task is null)
            throw new Exception($"Task with id {model.TaskId} was not found");
        
        if (task.TaskList.Id == model.TaskListDestinationId)
            throw new Exception($"Task {model.TaskId} already in tasklist {model.TaskListDestinationId}");

        var taskList = await _context.TaskLists.Include(x => x.Tasks).FirstOrDefaultAsync(x => x.Id == task.TaskListId);

        if (taskList.Tasks.Count == 1)
            _context.TaskLists.Remove(taskList);
        
        task.TaskListId = model.TaskListDestinationId;

        _context.Tasks.Update(task);
        await _context.SaveChangesAsync();

        return true;
    }

    public async Task<bool> ChangeTaskStatusAsync(ChangeTaskStatusModel requestModel)
    {
        var task = await _context.Tasks
            .Include(x => x.History)
            .Include(x => x.TaskList)
            .FirstOrDefaultAsync(x => x.TaskList.UserId == requestModel.UserId && x.Id == requestModel.TaskId);

        if (task.Status == requestModel.Status)
            throw new Exception($"Task already have a {requestModel.Status.ToString()} status.");

        _context.TaskHistories.Add(new TaskHistory()
        {
            Id = Guid.NewGuid(),
            Date = DateTime.Now,
            Status = requestModel.Status,
            TaskId = task.Id
        });
        task.Status = requestModel.Status;
        
        _context.Entry(task).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        
        return true;
    }
}
using BB.TaskManager.API.Extensions;
using BB.TaskManager.Application.MediatR.Commands;
using BB.TaskManager.Application.ViewModels;
using BB.TaskManager.Application.ViewModels.TaskViewModels.TaskViewModels;
using BB.TaskManager.Contracts.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BB.TaskManager.API.Controllers;

[Route("api/[controller]/")]
[Authorize]
public class TaskController : ControllerBase
{
    private readonly IMediator _mediator;

    public TaskController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpPost("create-list")]
    public async Task<IActionResult> CreateTaskListAsync([FromBody] CreateTaskListVm model)
    {
        var command = new CreateTaskListCommand
        {
            Model = new CreateTaskListModel()
            {
                UserId = User.GetUserId(),
                Title = model.Title,
                Description = model.Description
            }
        };
        
        var result = await _mediator.Send(command);
        
        return Ok(result);
    }
    
    [HttpGet("get-lists")]
    public async Task<IActionResult> GetTaskListsAsync(GetTaskListFilter filter)
    {
        var query = new GetTaskListsQuery()
        {
            UserId = User.GetUserId(),
            Filter = filter
        };
        
        var result = await _mediator.Send(query);
        
        return Ok(result);
    }
    
    [HttpPut("update-list")]
    public async Task<IActionResult> UpdateTaskListAsync(UpdateTaskListVm model)
    {
        var command = new UpdateTaskListCommand
        {
            Model = new UpdateTaskListModel()
            {
                UserId = User.GetUserId(),
                Title = model.Title,
                TaskListId = model.TaskListId,
                Description = model.Description
            }
        };
        
        var result = await _mediator.Send(command);
        
        return Ok(result);
    }

    [HttpDelete("delete-task-list")]
    public async Task<IActionResult> DeleteTaskList(DeleteTaskListVm model)
    {
        var command = new DeleteTaskListCommand
        {
            Model = new DeleteTaskListModel()
            {
                UserId = User.GetUserId(),
                TaskListId = model.Id
            }
        };
        
        var result = await _mediator.Send(command);

        if (result)
            return Ok(result);

        return BadRequest();
    }
    
    
    [HttpPost("create")]
    public async Task<IActionResult> CreateTaskAsync(CreateTaskVm model)
    {
        var command = new CreateTaskCommand
        {
            Model = new CreateTaskModel()
            {
                UserId = User.GetUserId(),
                Title = model.Title,
                Description = model.Description,
                TaskListId = model.TaskListId
            }
        };
        
        var result = await _mediator.Send(command);
        
        return Ok(result);
    }
    
    [HttpPut("update")]
    public async Task<IActionResult> UpdateTaskAsync(UpdateTaskVm model)
    {
        var command = new UpdateTaskCommand
        {
            Model = new UpdateTaskModel()
            {
                UserId = User.GetUserId(),
                TaskId = model.Id,
                Title = model.Title,
                Description = model.Description,
            }
        };
        var result = await _mediator.Send(command);
        return Ok(result);
    }

    [HttpDelete("delete")]
    public async Task<IActionResult> DeleteTaskAsync(DeleteTaskVm model)
    {
        var command = new DeleteTaskCommand
        {
            Model = new DeleteTaskModel()
            {
                TaskId = model.Id,
                UserId = User.GetUserId()
            }
        };
        
        var result = await _mediator.Send(command);
        
        return Ok(result);
    }

    [HttpPut("move")]
    public async Task<IActionResult> MoveTaskAsync(MoveTaskVm model)
    {
        var command = new MoveTaskCommand
        {
            Model = new MoveTaskModel()
            {
                TaskListDestinationId = model.TaskListDestinationId,
                UserId = User.GetUserId(),
                TaskId = model.TaskId
            }
        };
        
        var result = await _mediator.Send(command);
        
        return Ok(result);
    }
    
    [HttpPut("change-status")]
    public async Task<IActionResult> MoveTaskAsync(ChangeTaskStatusVm model)
    {
        var command = new ChangeTaskHistoryCommand()
        {
            Model = new ChangeTaskStatusModel()
            {
                UserId = User.GetUserId(),
                TaskId = model.TaskId,
                Status = model.Status
            }
        };
        
        var result = await _mediator.Send(command);
        
        return Ok(result);
    }
    
    
    
}
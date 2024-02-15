using BB.TaskManager.Application.Interfaces;
using BB.TaskManager.Application.MediatR.Commands;
using MediatR;

namespace BB.TaskManager.Application.MediatR.Handlers;

public class UpdateTaskListCommandHandler : IRequestHandler<UpdateTaskListCommand, Guid>
{
    private readonly ITaskService _taskService;

    public UpdateTaskListCommandHandler(ITaskService taskService)
    {
        _taskService = taskService;
    }
    
    public async Task<Guid> Handle(UpdateTaskListCommand request, CancellationToken cancellationToken)
    {
        return await _taskService.UpdateTaskListAsync(request.Model);
    }
}
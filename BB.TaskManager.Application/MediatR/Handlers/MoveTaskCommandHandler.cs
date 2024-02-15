using BB.TaskManager.Application.Interfaces;
using BB.TaskManager.Application.MediatR.Commands;
using MediatR;

namespace BB.TaskManager.Application.MediatR.Handlers;

public class MoveTaskCommandHandler : IRequestHandler<MoveTaskCommand, bool>
{
    private readonly ITaskService _taskService;

    public MoveTaskCommandHandler(ITaskService taskService)
    {
        _taskService = taskService;
    }
    
    public async Task<bool> Handle(MoveTaskCommand request, CancellationToken cancellationToken)
    {
        return await _taskService.MoveTaskAsync(request.Model);
    }
}
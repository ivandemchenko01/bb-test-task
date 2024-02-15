using BB.TaskManager.Application.Interfaces;
using BB.TaskManager.Application.MediatR.Commands;
using MediatR;

namespace BB.TaskManager.Application.MediatR.Handlers;

public class UpdateTaskCommandHandler : IRequestHandler<UpdateTaskCommand, Guid>
{
    private readonly ITaskService _taskService;

    public UpdateTaskCommandHandler(ITaskService taskService)
    {
        _taskService = taskService;
    }
    
    public async Task<Guid> Handle(UpdateTaskCommand request, CancellationToken cancellationToken)
    {
        return await _taskService.UpdateTaskAsync(request.Model);
    }
}
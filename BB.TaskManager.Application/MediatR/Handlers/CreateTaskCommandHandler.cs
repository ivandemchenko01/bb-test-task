using BB.TaskManager.Application.Interfaces;
using BB.TaskManager.Application.MediatR.Commands;
using MediatR;

namespace BB.TaskManager.Application.MediatR.Handlers;

public class CreateTaskCommandHandler : IRequestHandler<CreateTaskCommand, Guid>
{
    private readonly ITaskService _taskService;

    public CreateTaskCommandHandler(ITaskService taskService)
    {
        _taskService = taskService;
    }
    
    public async Task<Guid> Handle(CreateTaskCommand request, CancellationToken cancellationToken)
    {
        return await _taskService.CreateTaskAsync(request.Model);
    }
}
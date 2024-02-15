using BB.TaskManager.Application.Interfaces;
using BB.TaskManager.Application.MediatR.Commands;
using MediatR;

namespace BB.TaskManager.Application.MediatR.Handlers;

public class CreateTaskListCommandHandler : IRequestHandler<CreateTaskListCommand, Guid>
{
    private readonly ITaskService _taskService;

    public CreateTaskListCommandHandler(ITaskService taskService)
    {
        _taskService = taskService;
    }
    
    public async Task<Guid> Handle(CreateTaskListCommand request, CancellationToken cancellationToken)
    {
        return await _taskService.CreateTaskListAsync(request.Model);
    }
}
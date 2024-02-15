using BB.TaskManager.Application.Interfaces;
using BB.TaskManager.Application.MediatR.Commands;
using MediatR;

namespace BB.TaskManager.Application.MediatR.Handlers;

public class DeleteTaskListCommandHandler : IRequestHandler<DeleteTaskListCommand, bool>
{
    private readonly ITaskService _taskService;

    public DeleteTaskListCommandHandler(ITaskService taskService)
    {
        _taskService = taskService;
    }
    
    public async Task<bool> Handle(DeleteTaskListCommand request, CancellationToken cancellationToken)
    {
        return await _taskService.DeleteTaskListAsync(request.Model);
    }
}
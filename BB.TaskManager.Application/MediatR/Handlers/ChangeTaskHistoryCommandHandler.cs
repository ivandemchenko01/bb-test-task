using BB.TaskManager.Application.Interfaces;
using BB.TaskManager.Application.MediatR.Commands;
using MediatR;

namespace BB.TaskManager.Application.MediatR.Handlers;

public class ChangeTaskHistoryCommandHandler : IRequestHandler<ChangeTaskHistoryCommand, bool>
{
    private readonly ITaskService _service;

    public ChangeTaskHistoryCommandHandler(ITaskService service)
    {
        _service = service;
    }
    
    public async Task<bool> Handle(ChangeTaskHistoryCommand request, CancellationToken cancellationToken)
    {
        return await _service.ChangeTaskStatusAsync(request.Model);
    }
}
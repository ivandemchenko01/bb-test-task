using BB.TaskManager.Contracts.Models;
using MediatR;

namespace BB.TaskManager.Application.MediatR.Commands;

public class UpdateTaskCommand : IRequest<Guid>
{
    public UpdateTaskModel Model { get; set; }    
}
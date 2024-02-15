using BB.TaskManager.Contracts.Models;
using MediatR;

namespace BB.TaskManager.Application.MediatR.Commands;

public class UpdateTaskListCommand : IRequest<Guid>
{
    public UpdateTaskListModel Model { get; set; }    
}
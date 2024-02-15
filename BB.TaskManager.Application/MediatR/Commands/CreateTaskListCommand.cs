using BB.TaskManager.Contracts.Models;
using MediatR;

namespace BB.TaskManager.Application.MediatR.Commands;

public class CreateTaskListCommand : IRequest<Guid>
{
    public CreateTaskListModel Model { get; set; }
}
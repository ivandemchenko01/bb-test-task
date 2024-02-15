using BB.TaskManager.Contracts.Models;
using MediatR;

namespace BB.TaskManager.Application.MediatR.Commands;

public class DeleteTaskListCommand : IRequest<bool>
{
    public DeleteTaskListModel Model { get; set; }
}
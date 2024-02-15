using BB.TaskManager.Contracts.Models;
using MediatR;

namespace BB.TaskManager.Application.MediatR.Commands;

public class DeleteTaskCommand : IRequest<bool>
{
    public DeleteTaskModel Model { get; set; }
}
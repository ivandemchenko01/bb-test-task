using BB.TaskManager.Contracts.Models;
using MediatR;

namespace BB.TaskManager.Application.MediatR.Commands;

public class MoveTaskCommand : IRequest<bool>
{
    public MoveTaskModel Model { get; set; }
}
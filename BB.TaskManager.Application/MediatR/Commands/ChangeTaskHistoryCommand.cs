using BB.TaskManager.Contracts.Models;
using MediatR;

namespace BB.TaskManager.Application.MediatR.Commands;

public class ChangeTaskHistoryCommand : IRequest<bool>
{
    public ChangeTaskStatusModel Model { get; set; }
}
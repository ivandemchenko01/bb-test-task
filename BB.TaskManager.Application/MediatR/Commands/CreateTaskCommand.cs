using BB.TaskManager.Contracts.Models;
using MediatR;

namespace BB.TaskManager.Application.MediatR.Commands;

public class CreateTaskCommand : IRequest<Guid>
{
    public CreateTaskModel Model { get; set; }
}
using BB.TaskManager.Application.DTOs;
using BB.TaskManager.Contracts.Models;
using MediatR;

namespace BB.TaskManager.Application.MediatR.Commands;

public class GetTaskListsQuery : IRequest<List<TaskListDto>>
{
    public Guid UserId { get; set; }
    public GetTaskListFilter Filter { get; set; }
}
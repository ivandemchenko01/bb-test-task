using AutoMapper;
using BB.TaskManager.Application.DTOs;
using BB.TaskManager.Application.Interfaces;
using BB.TaskManager.Application.MediatR.Commands;
using BB.TaskManager.Contracts.Models;
using MediatR;

namespace BB.TaskManager.Application.MediatR.Handlers;

public class GetTaskListsQueryHandler : IRequestHandler<GetTaskListsQuery, List<TaskListDto>>
{
    private readonly ITaskService _taskService;
    private readonly IMapper _mapper;

    public GetTaskListsQueryHandler(ITaskService taskService, IMapper mapper)
    {
        _taskService = taskService;
        _mapper = mapper;
    }
    
    public async Task<List<TaskListDto>> Handle(GetTaskListsQuery request, CancellationToken cancellationToken)
    {
        var result = await _taskService.GetTaskListsAsync(request.UserId, request.Filter);

        return _mapper.Map<List<TaskListDto>>(result);
    }
}
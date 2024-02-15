using AutoMapper;
using BB.TaskManager.Application.DTOs;
using BB.TaskManager.Domain.Models;
using Task = BB.TaskManager.Domain.Models.Task;

namespace BB.TaskManager.Application.Configuration;

public class MapperConfiguration : Profile
{
    public MapperConfiguration()
    {
        CreateMap<Task, TaskDto>()
            .ReverseMap();

        CreateMap<TaskList, TaskListDto>()
            .ReverseMap();

        CreateMap<TaskHistory, TaskHistoryDto>()
            .ReverseMap();
    }
}
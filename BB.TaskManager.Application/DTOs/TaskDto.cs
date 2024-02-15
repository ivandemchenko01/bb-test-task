﻿namespace BB.TaskManager.Application.DTOs;

public class TaskDto
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string Status { get; set; }
    public List<TaskHistoryDto> History { get; set; }
}
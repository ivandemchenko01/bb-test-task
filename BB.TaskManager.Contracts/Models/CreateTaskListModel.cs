﻿namespace BB.TaskManager.Contracts.Models;

public class CreateTaskListModel
{
    public Guid UserId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
}
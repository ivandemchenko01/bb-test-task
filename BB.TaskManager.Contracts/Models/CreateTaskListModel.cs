namespace BB.TaskManager.Contracts.Models;

public class CreateTaskListModel
{
    public Guid UserId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
}

public class UpdateTaskListModel
{
    public Guid UserId { get; set; }
    public Guid TaskListId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
}

public class DeleteTaskListModel
{
    public Guid UserId { get; set; }
    public Guid TaskListId { get; set; }
}

public class DeleteTaskModel
{
    public Guid UserId { get; set; }
    public Guid TaskId { get; set; }
}

public class MoveTaskModel
{
    public Guid UserId { get; set; }
    public Guid TaskId { get; set; }
    public Guid TaskListDestinationId { get; set; }
}

public class CreateTaskModel
{
    public Guid UserId { get; set; }
    public Guid TaskListId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
}

public class UpdateTaskModel
{
    public Guid TaskId { get; set; }
    public Guid UserId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public TaskStatus Status { get; set; }
}

public class GetTaskListFilter
{
    public string TitleQuery { get; set; } = "";
    public string DescriptionQuery { get; set; } = "";
    public bool SortAscending = true;
    public int Page { get; set; } = 1;
}
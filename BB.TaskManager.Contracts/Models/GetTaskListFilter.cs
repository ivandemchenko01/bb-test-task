namespace BB.TaskManager.Contracts.Models;

public class GetTaskListFilter
{
    public string TitleQuery { get; set; } = "";
    public string DescriptionQuery { get; set; } = "";
    public bool SortAscending = true;
    public int Page { get; set; } = 1;
}
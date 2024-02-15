using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BB.TaskManager.Domain.Models;

public class TaskHistory
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)] 
    public Guid Id { get; set; }
    public Guid TaskId { get; set; }
    public Task Task { get; set; }
    public BB.TaskManager.Contracts.Enumerations.TaskStatus Status { get; set; }
    public DateTime Date { get; set; }
}
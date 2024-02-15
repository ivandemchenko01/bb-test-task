using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Task = BB.TaskManager.Domain.Models.Task;

namespace BB.TaskManager.Infrastructure.Configurations;

public class TaskConfiguration : IEntityTypeConfiguration<Task>
{
    public void Configure(EntityTypeBuilder<Task> builder)
    {
        builder
            .HasMany(x => x.History)
            .WithOne()
            .HasForeignKey(x => x.TaskId);
    }
}
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BB.TaskManager.Infrastructure;

public static class PersistenceExtensions
{
    public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseNpgsql(
                configuration.GetConnectionString("BBTaskManagerConnectionString"),
                x => x.MigrationsAssembly("BB.TaskManager.Infrastructure"));
        });
        
        return services;
    }
}
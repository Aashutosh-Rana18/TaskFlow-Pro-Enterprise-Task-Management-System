using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TaskFlowPro.Application.Interfaces;
using TaskFlowPro.Infrastructure.Identity;
using TaskFlowPro.Infrastructure.Persistence;
using TaskFlowPro.Infrastructure.Persistence.Repositories;

namespace TaskFlowPro.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
            // Using a generic LocalDb SQL Server connection string placeholder
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        
        services.AddScoped<IJwtService, JwtService>();

        return services;
    }
}

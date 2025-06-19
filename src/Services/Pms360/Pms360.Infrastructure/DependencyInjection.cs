using Microsoft.EntityFrameworkCore.Diagnostics;

namespace Pms360.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("Pms360ConnectionString");
        Guard.Against.Null(connectionString, message: "Connection string 'Pms360ConnectionString' not found.");

        services.AddDbContext<ApplicationDbContext>((sp, options) =>
        {
            options.UseSqlServer(connectionString, builder =>
            {
                builder.MigrationsHistoryTable("Migration", "PMS360");
            });
            options.AddInterceptors(sp.GetServices<ISaveChangesInterceptor>());
        });

        // Register IApplicationDbContext before services that depend on it
        services.AddScoped<IApplicationDbContext>(provider => provider.GetRequiredService<ApplicationDbContext>());
        services.AddScoped<IPMSTypesService, PMSTypeService>();

        return services;
    }
}

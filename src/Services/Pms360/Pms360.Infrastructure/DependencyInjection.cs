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

        services.AddScoped<IApplicationDbContext>(provider => provider.GetRequiredService<ApplicationDbContext>());
        services.AddScoped<IPMSTypesService, PMSTypeService>();
        services.AddScoped<IPMSDurationTypeService,PMSDurationTypeService>();

        return services;
    }
}

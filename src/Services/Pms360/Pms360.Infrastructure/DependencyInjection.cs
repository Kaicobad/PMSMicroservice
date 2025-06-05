namespace Pms360.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("Pms360ConnectionString");

        services.AddDbContext<ApplicationDbContext>(Option => Option.UseSqlServer(connectionString, builder=>
        {
            builder.MigrationsHistoryTable("Migration", "PMS360");
        }));


        return services;

    }
}

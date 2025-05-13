using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Pms360.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        //var connectionString = configuration.GetConnectionString("Pms360ConnectionString");
        //services.AddDbContext<ApplicationDbContex>(Options => Options.UseSqlServer(connectionString));
        //services.AddScoped<IApplicaionDbContect, ApplicaionDbContect>();

        return services;

    }
}

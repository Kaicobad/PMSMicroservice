using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Pms360.Infrastructure.Data;

namespace Pms360.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("Pms360ConnectionString");
        services.AddDbContext<ApplicationDbContext>(Options => Options.UseSqlServer(connectionString));
        //services.AddScoped<IApplicaionDbContext, ApplicaionDbContect>();

        return services;

    }
}

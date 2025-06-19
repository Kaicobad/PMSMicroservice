using Pms360.Infrastructure.Data;

namespace Pms360.API;

public static class DependencyInjection
{
    public static IServiceCollection AddApiServices(this IServiceCollection services)
    {
        //services.AddCarter();  
        services.AddExceptionHandler<CustomExceptionHandler>();  

        services.AddHttpContextAccessor();
        services.AddRazorPages();
        services.AddEndpointsApiExplorer();

        return services;
    }
}

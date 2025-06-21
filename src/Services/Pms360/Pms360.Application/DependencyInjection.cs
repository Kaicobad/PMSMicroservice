
using Pms360.Application.Common.Behavior;

namespace Pms360.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        var assembly = Assembly.GetExecutingAssembly();

        services.AddValidatorsFromAssembly(assembly);

        services.AddMediatR(cfg => {
            cfg.RegisterServicesFromAssembly(assembly);
            
        })
        .AddValidatorsFromAssembly(assembly)
        .AddTransient(typeof(IPipelineBehavior<,>),typeof(ValidationBehavior<,>));

        return services;
    }
}

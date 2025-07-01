using Microsoft.EntityFrameworkCore.Diagnostics;
using Pms360.Application.Features.CommonDepartments;
using Pms360.Application.Features.CommonUnits;
using Pms360.Infrastructure.CoreERPData;
using Pms360.Infrastructure.CoreERPServices;

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

        #region CoreERPContext
        var coreErpConnection = configuration.GetConnectionString("CoreErpConnectionString");
        Guard.Against.Null(coreErpConnection, message: "Connection string 'CoreERPConnectionString' not found.");

        services.AddDbContext<CoreERPDbContext>(options =>
            options.UseSqlServer(coreErpConnection));
        #endregion

        services.AddScoped<IApplicationDbContext>(provider => provider.GetRequiredService<ApplicationDbContext>());
        services.AddScoped<IPMSTypesService, PMSTypeService>();
        services.AddScoped<IPMSDurationTypeService,PMSDurationTypeService>();
        services.AddScoped<IPMSCycleService,PMSCycleService>();
        services.AddScoped<IHumanResourceEmployeeBasicService, HumanResourceEmployeeBasicService>();
        services.AddScoped<ICommonDepartmentService,CommonDepartmentService>();
        services.AddScoped<ICommonUnitService, CommonUnitService>();
        services.AddScoped<ICommonCompanyService, CommonCompanyService>();
        services.AddScoped<IMapper,Mapper>();

        return services;
    }

}

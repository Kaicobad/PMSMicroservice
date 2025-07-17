namespace Pms360.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        #region PMS DbContext
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
        #endregion

        #region CoreERPContext
        var coreErpConnection = configuration.GetConnectionString("CoreErpConnectionString");
        Guard.Against.Null(coreErpConnection, message: "Connection string 'CoreERPConnectionString' not found.");

        services.AddDbContext<CoreERPDbContext>(options =>
            options.UseSqlServer(coreErpConnection));
        #endregion

        #region AuthApiContext
        var AuthApiConnection = configuration.GetConnectionString("AuthConnectionString");
        Guard.Against.Null(AuthApiConnection, message: "Connection string 'AuthApiConnectionString' not found.");

        services.AddDbContext<AuthDbContext>(options =>
            options.UseSqlServer(AuthApiConnection));
        #endregion

        services.AddScoped<IApplicationDbContext>(provider => provider.GetRequiredService<ApplicationDbContext>());
        services.AddScoped<IPMSTypesService, PMSTypeService>();
        services.AddScoped<IPMSDurationTypeService, PMSDurationTypeService>();
        services.AddScoped<IPMSCycleService, PMSCycleService>();
        services.AddScoped<IHumanResourceEmployeeBasicService, HumanResourceEmployeeBasicService>();
        services.AddScoped<ICommonDepartmentService, CommonDepartmentService>();
        services.AddScoped<ICommonUnitService, CommonUnitService>();
        services.AddScoped<ICommonCompanyService, CommonCompanyService>();
        services.AddScoped<ICommonSectionService, CommonSectionService>();
        services.AddScoped<ICommonWingService, CommonWingService>();
        services.AddScoped<ICommonTeamService, CommonTeamService>();
        services.AddScoped<IAssessorTypeService, AssessorTypeService>();
        services.AddScoped<IAssessorMasterService, AssessorMasterService>();
        services.AddScoped<IAssessorTypeMapService, AssessorTypeMapService>();
        services.AddScoped<IAssessorUserMapService, AssessorUserMapService>();
        services.AddScoped<IAspNetUsersService,AspNetUsersService>();
        services.AddScoped<IMapper, Mapper>();
        services.AddScoped<CurrentUserService>();
        services.AddScoped<ICurrentUserService>(provider => provider.GetRequiredService<CurrentUserService>());

        return services;
    }
}

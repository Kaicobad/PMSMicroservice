namespace Pms360.Infrastructure.CoreERPServices;
public class CommonDepartmentService(CoreERPDbContext dbContext) : ICommonDepartmentService
{
    private readonly CoreERPDbContext _dbContext = dbContext;

    public async Task<List<CommonDepartment>> GetAllAsync(CancellationToken cancellationToken)
    {
        var departments = await _dbContext.CommonDepartments.Where(x => x.IsActive == true).ToListAsync(cancellationToken);
        Guard.Against.NotFound("CommonDepartments", departments);
        return departments;
    }

    public async Task<CommonDepartment> GetByIdAsync(int DepartmentId, CancellationToken cancellationToken)
    {
        var department = await _dbContext.CommonDepartments.Where(x => x.DepartmentId == DepartmentId).FirstOrDefaultAsync(cancellationToken);
        Guard.Against.NotFound("CommonDepartment", department);
        return department;
    }
}

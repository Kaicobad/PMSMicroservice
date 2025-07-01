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

    public async Task<List<CommonDepartment>> GetByUnitIdAsync(int unitId, CancellationToken cancellationToken)
    {
        var departmentsByUnit = await (from CD  in _dbContext.CommonDepartments
                                       join RUD in _dbContext.RUnitDepts 
                                       on CD.DepartmentId equals RUD.DepartmentId
                                       where RUD.UnitId == unitId && CD.IsActive == true
                                       select new CommonDepartment
                                       {
                                           DepartmentId = CD.DepartmentId,
                                           DepartmentName = CD.DepartmentName,
                                           DepartmentNameBan = CD.DepartmentNameBan,
                                           DepartmentShortName = CD.DepartmentShortName

                                       }).ToListAsync(cancellationToken);
        Guard.Against.NotFound("CommonDepartment", departmentsByUnit);
        return departmentsByUnit;

    }

    public async Task<bool> IsExistsAsync(int DepartmentId, CancellationToken cancellationToken)
    {
        return await _dbContext.CommonDepartments.AnyAsync(dept => dept.DepartmentId == DepartmentId, cancellationToken);
    }
}

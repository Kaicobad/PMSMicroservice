namespace Pms360.Infrastructure.CoreERPServices;
public class HumanResourceEmployeeBasicService(CoreERPDbContext dbContext) : IHumanResourceEmployeeBasicService
{
    private readonly CoreERPDbContext _dbContext = dbContext;

    public async Task<List<HumanResourceEmployeeBasic>> GetByAllFilterAsync(int CompanyId, int UnitId, int DepartmentId, int DesignationId, int SectionId, int WingId, int TeamId, CancellationToken cancellationToken)
    {

        var query = _dbContext.HumanResourceEmployeeBasics
            .Join(_dbContext.CommonUnits,
                  emp => emp.UnitId,
                  unit => unit.UnitId,
                  (emp, unit) => new { emp, unit.CompanyId })
            .Where(x => x.emp.EmpStatusId == 1);

        if (CompanyId != 0)
            query = query.Where(x => x.CompanyId == CompanyId);
        if (UnitId != 0)
            query = query.Where(x => x.emp.UnitId == UnitId);
        if (DepartmentId != 0)
            query = query.Where(x => x.emp.DepartmentId == DepartmentId);
        if (DesignationId != 0)
            query = query.Where(x => x.emp.DesignationId == DesignationId);
        if (SectionId != 0)
            query = query.Where(x => x.emp.SectionId == SectionId);
        if (WingId != 0)
            query = query.Where(x => x.emp.WingId == WingId);
        if (TeamId != 0)
            query = query.Where(x => x.emp.TeamId == TeamId);

        var result = await query
            .Select(x => x.emp)
            .ToListAsync(cancellationToken);

        Guard.Against.NotFound("HumanResourceEmployeeBasics", result);
        return result;
    }

    public async Task<HumanResourceEmployeeBasic> GetByCodeAsync(string EmpCode, CancellationToken cancellationToken)
    {
        return await _dbContext.HumanResourceEmployeeBasics.FirstOrDefaultAsync(x => x.EmpCode == EmpCode && x.EmpStatusId == 1, cancellationToken);
    }

    public async Task<List<HumanResourceEmployeeBasic>> GetByDepartmentAsync(int DepartmentId, CancellationToken cancellationToken)
    {
        var basics = await _dbContext.HumanResourceEmployeeBasics.Where(x => x.DepartmentId == DepartmentId && x.EmpStatusId == 1).ToListAsync(cancellationToken);
        Guard.Against.NotFound("HumanResourceEmployeeBasics", basics);
        return basics;
    }

    public async Task<List<HumanResourceEmployeeBasic>> GetBySectionAsync(int SectionId, CancellationToken cancellationToken)
    {
        var basics = await _dbContext.HumanResourceEmployeeBasics.Where(x => x.SectionId == SectionId && x.EmpStatusId == 1).ToListAsync(cancellationToken);
        Guard.Against.NotFound("HumanResourceEmployeeBasics", basics);
        return basics;
    }

    public async Task<List<HumanResourceEmployeeBasic>> GetByTeamAsync(int TeamId, CancellationToken cancellationToken)
    {
        var basics = await _dbContext.HumanResourceEmployeeBasics.Where(x => x.TeamId == TeamId && x.EmpStatusId == 1).ToListAsync(cancellationToken);
        Guard.Against.NotFound("HumanResourceEmployeeBasics", basics);
        return basics;
    }

    public async Task<List<HumanResourceEmployeeBasic>> GetByUnitAsync(int UnitId, CancellationToken cancellationToken)
    {
        var basics = await _dbContext.HumanResourceEmployeeBasics.Where(x => x.UnitId == UnitId && x.EmpStatusId == 1).ToListAsync(cancellationToken);
        Guard.Against.NotFound("HumanResourceEmployeeBasics", basics);
        return basics;
    }

    public async Task<List<HumanResourceEmployeeBasic>> GetByWingAsync(int WingId, CancellationToken cancellationToken)
    {
        var basics = await _dbContext.HumanResourceEmployeeBasics.Where(x => x.WingId == WingId && x.EmpStatusId == 1).ToListAsync(cancellationToken);
        Guard.Against.NotFound("HumanResourceEmployeeBasics", basics);
        return basics;
    }

    public async Task<bool> IsExistsByEmpCodeAsync(string EmpCode, CancellationToken cancellationToken)
    {
        return await _dbContext.HumanResourceEmployeeBasics.AnyAsync(x => x.EmpCode == EmpCode && x.EmpStatusId == 1, cancellationToken);
    }
}

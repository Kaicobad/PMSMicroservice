namespace Pms360.Infrastructure.CoreERPServices;
public class CommonUnitService(CoreERPDbContext dbContext) : ICommonUnitService
{
    private readonly CoreERPDbContext _dbContext = dbContext;

    public async Task<List<CommonUnit>> GetAllAsync(CancellationToken cancellationToken)
    {
        var units = await _dbContext.CommonUnits.Where(x => x.IsActive == true).ToListAsync(cancellationToken);
        Guard.Against.NotFound("CommonUnits", units);
        return units;
    }

    public async Task<List<CommonUnit>> GetByCompanyId(int CompanyId, CancellationToken cancellationToken)
    {
        var units = await _dbContext.CommonUnits.Where(x => x.CompanyId == CompanyId && x.IsActive == true).ToListAsync(cancellationToken);
        Guard.Against.NotFound("CommonUnits", units);
        return units;
    }

    public async Task<CommonUnit> GetByIdAsync(int UnitId, CancellationToken cancellationToken)
    {
        var response = await _dbContext.CommonUnits.Where(x => x.UnitId == UnitId && x.IsActive == true).FirstOrDefaultAsync(cancellationToken);
        Guard.Against.NotFound("CommonUnit", response);
        return response;

    }

    public async Task<bool> IsExistsAsync(int UnitId, CancellationToken cancellationToken)
    {
        return await _dbContext.CommonUnits.AnyAsync(units => units.UnitId == UnitId, cancellationToken);
    }
}

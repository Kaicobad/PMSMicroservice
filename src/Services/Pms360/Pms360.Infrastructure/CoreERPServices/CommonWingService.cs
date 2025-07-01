namespace Pms360.Infrastructure.CoreERPServices;
public class CommonWingService(CoreERPDbContext dbContext) : ICommonWingService
{
    private readonly CoreERPDbContext _dbContext = dbContext;

    public async Task<List<CommonWing>> GetAllByUnitDeptAndSection(int UnitId, int DepartmentId, int SectionId, CancellationToken cancellationToken)
    {
        var result = await (from cw in _dbContext.CommonWings
                            join sw in _dbContext.RSecWings on cw.WingId equals sw.WingId
                            join ds in _dbContext.RDeptSections on sw.DsecId equals ds.DsecId
                            join ud in _dbContext.RUnitDepts on ds.UdepId equals ud.UdepId
                            where cw.IsActive == true
                                  && ud.UnitId == UnitId
                                  && ud.DepartmentId == DepartmentId
                                  && ds.SectionId == SectionId
                            select new CommonWing
                            {
                                WingId = cw.WingId,
                                WingName = cw.WingName,
                                WingNameBan = cw.WingNameBan
                            }).ToListAsync(cancellationToken);
        Guard.Against.NotFound("CommonWings", result);
        return result;
    }

    public async Task<bool> IsExistsAsync(int WingId, CancellationToken cancellationToken)
    {
        return await _dbContext.CommonWings.AnyAsync(wng => wng.WingId == WingId,cancellationToken);
    }
}

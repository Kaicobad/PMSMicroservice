
using Azure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Pms360.Infrastructure.CoreERPServices;
public class CommonSectionService(CoreERPDbContext dbContext) : ICommonSectionService
{
    private readonly CoreERPDbContext _dbContext = dbContext;

    public async Task<List<CommonSection>> GetAllAsync(CancellationToken cancellationToken)
    {
        var types = await _dbContext.CommonSections.Where(x => x.IsActive == true).ToListAsync(cancellationToken);
        Guard.Against.NotFound("CommonSections", types);
        return types;
    }

    public async Task<List<CommonSection>> GetByUnitAndDeptAsync(int UnitId, int DeptId, CancellationToken cancellationToken)
    {
        var sectionByUnitIdAndDeprId = await (from sec in _dbContext.CommonSections
                                join dpSec in _dbContext.RDeptSections on sec.SectionId equals dpSec.SectionId
                                join unitDept in _dbContext.RUnitDepts on dpSec.UdepId equals unitDept.UdepId
                                where sec.IsActive == true
                                      && unitDept.UnitId == UnitId
                                      && unitDept.DepartmentId == DeptId
                                select new CommonSection
                                {
                                    SectionId = sec.SectionId,
                                    SectionName = sec.SectionName,
                                    SectionShortName = sec.SectionShortName
                                }).ToListAsync(cancellationToken);

        Guard.Against.NotFound("CommonSections", sectionByUnitIdAndDeprId);
        return sectionByUnitIdAndDeprId;
    }

    public async Task<bool> IsExistsAsync(int SectionId, CancellationToken cancellationToken)
    {
        return await _dbContext.CommonSections.AnyAsync(sec => sec.SectionId == SectionId,cancellationToken);
    }
}

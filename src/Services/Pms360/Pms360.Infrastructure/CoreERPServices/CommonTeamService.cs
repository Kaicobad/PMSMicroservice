
using MediatR;
using static System.Collections.Specialized.BitVector32;

namespace Pms360.Infrastructure.CoreERPServices;
public class CommonTeamService(CoreERPDbContext dbContext) : ICommonTeamService
{
    private readonly CoreERPDbContext _dbContext = dbContext;

    public async Task<List<CommonTeam>> GetTeamsByUnitDepartmentSectionAndWingAsync(int UnitId, int DepartmentId, int SectionId, int WingId, CancellationToken cancellationToken)
    {
        var result = await (from team in _dbContext.CommonTeams
                            join wt in _dbContext.RWingTeams on team.TeamId equals wt.TeamId
                            join sw in _dbContext.RSecWings on wt.SwingId equals sw.SwingId
                            join ds in _dbContext.RDeptSections on sw.DsecId equals ds.DsecId
                            join ud in _dbContext.RUnitDepts on ds.UdepId equals ud.UdepId
                            where team.IsActive == true
                                  && ud.UnitId == UnitId
                                  && ud.DepartmentId == DepartmentId
                                  && ds.SectionId == SectionId
                                  && sw.WingId == WingId
                            select new CommonTeam
                            {
                                TeamId = team.TeamId,
                                TeamName = team.TeamName
                            }).ToListAsync(cancellationToken);
        Guard.Against.NotFound("CommonTeams", result);
        return result;
    }

    public async Task<bool> IsExistsAsync(int TeamId, CancellationToken cancellationToken)
    {
        return await _dbContext.CommonTeams.AnyAsync(team => team.TeamId == TeamId, cancellationToken);
    }
}

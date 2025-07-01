namespace Pms360.Application.Features.CommonTeams;
public interface ICommonTeamService
{
    Task<List<CommonTeam>> GetTeamsByUnitDepartmentSectionAndWingAsync(int UnitId, int DepartmentId, int SectionId, int WingId, CancellationToken cancellationToken);
    Task<bool> IsExistsAsync(int TeamId, CancellationToken cancellationToken);
}

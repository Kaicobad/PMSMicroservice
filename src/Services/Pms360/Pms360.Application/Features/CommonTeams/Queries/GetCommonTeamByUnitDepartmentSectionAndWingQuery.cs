
namespace Pms360.Application.Features.CommonTeams.Queries;
public class GetCommonTeamByUnitDepartmentSectionAndWingQuery : IRequest<IResponse<List<CommonTeam>>>
{
    public int UnitId { get; set; }
    public int DepartmentId { get; set; }
    public int SectionId { get; set; }
    public int WingId { get; set; }
}
public class GetCommonTeamByUnitDepartmentSectionAndWingQueryHandle(ICommonTeamService service) : IRequestHandler<GetCommonTeamByUnitDepartmentSectionAndWingQuery, IResponse<List<CommonTeam>>>
{
    private readonly ICommonTeamService _service = service;

    public async Task<IResponse<List<CommonTeam>>> Handle(GetCommonTeamByUnitDepartmentSectionAndWingQuery request, CancellationToken cancellationToken)
    {
        var teams = await _service.GetTeamsByUnitDepartmentSectionAndWingAsync(request.UnitId,request.DepartmentId,request.SectionId,request.WingId,cancellationToken);
        if (teams.Count > 0)
        {
            return Response<List<CommonTeam>>.Success(teams);
        }
        return Response<List<CommonTeam>>.Fail("Team Doesn't Exists !");
    }
}

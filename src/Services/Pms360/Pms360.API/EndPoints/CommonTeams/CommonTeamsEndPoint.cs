using Pms360.Application.Features.CommonTeams.Queries;

namespace Pms360.API.EndPoints.CommonTeams;

public class CommonTeamsEndPoint : EndPointGroupBase
{
    private const string RoutePrefix = "api/v1/pms360/teams";

    public override void Map(WebApplication app)
    {
        var group = app.MapGroup(RoutePrefix).WithTags("CoreERPCommonTeam").WithDescription("Works with retrive Team Information")
            .RequireAuthorization();


        //group.MapGet("getAll", GetPmsTypes);
        group.MapGet("getbyUnitDeptSectionAndWing", GetCommonSectionByUnitDepartmentSectionAndWing); ;
    }
    public async Task<IResult> GetCommonSectionByUnitDepartmentSectionAndWing(ISender sender, [AsParameters] GetCommonTeamByUnitDepartmentSectionAndWingQuery query)
    {
        var result = await sender.Send(query);

        if (result.IsSuccessful)
        {
            return Results.Ok(result);
        }
        return Results.BadRequest(result);

    }
}


using Pms360.Application.Features.CommonWings.Queries;

namespace Pms360.API.EndPoints.CommonWings;

public class CommonWingEndPoint : EndPointGroupBase
{
    private const string RoutePrefix = "api/v1/pms360/wings";

    public override void Map(WebApplication app)
    {
        var group = app.MapGroup(RoutePrefix).WithTags("CoreERPCommonWing").WithDescription("Works with retriving wings information !")
            .RequireAuthorization();

        group.MapGet("getAllbyUnitDepartmentAndSection", GetCommonWingsByUnitDepartmentAndSection);

    }
    public async Task<IResult> GetCommonWingsByUnitDepartmentAndSection(ISender sender, [AsParameters] GetCommonWingByUnitDepartmentAndSectionQuery query)
    {
        var result = await sender.Send(query);
        if (result.IsSuccessful)
        {
            return Results.Ok(result);
        }
        return Results.BadRequest(result);

    }
}


using Pms360.Application.Features.AssessorTypeMaps.Queries;
using Pms360.Application.Features.AssessorUserMaps.Commands;
using Pms360.Application.Features.AssessorUserMaps.Queries;

namespace Pms360.API.EndPoints.AssessorUserMaps;

public class AssessorUserMapEndPoint : EndPointGroupBase
{
    private const string RoutePrefix = "api/v1/pms360/assessorUserMap";

    public override void Map(WebApplication app)
    {
        var group = app.MapGroup(RoutePrefix).WithTags("AssessorUserMap").WithDescription("Works with Assessor User Mapping Set Up !")
            .RequireAuthorization();

        group.MapPost("create", CreateAssessorUserMap);
        group.MapGet("getAll", GetAssessorUserMaps);
    }
    public async Task<IResult> CreateAssessorUserMap(ISender sender, [AsParameters] CreateAssessorUserMapCommand command)
    {
        var result = await sender.Send(command);
        if (result.IsSuccessful)
        {
            return Results.Ok(result);
        }
        return Results.BadRequest(result);

    }
    public async Task<IResult> GetAssessorUserMaps(ISender sender)
    {
        var result = await sender.Send(new GetAssessorUserMapQuery());
        if (result.IsSuccessful)
        {
            return Results.Ok(result);
        }
        return Results.BadRequest(result);
    }
}

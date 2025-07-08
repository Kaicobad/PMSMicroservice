
using Pms360.Application.Features.AssessorUserMaps.Commands;

namespace Pms360.API.EndPoints.AssessorUserMaps;

public class AssessorUserMapEndPoint : EndPointGroupBase
{
    private const string RoutePrefix = "api/v1/pms360/assessorUserMap";

    public override void Map(WebApplication app)
    {
        var group = app.MapGroup(RoutePrefix).WithTags("AssessorUserMap").WithDescription("Works with Assessor User Mapping Set Up !")
            .RequireAuthorization();

        group.MapPost("create", CreateAssessorUserMap);
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
}

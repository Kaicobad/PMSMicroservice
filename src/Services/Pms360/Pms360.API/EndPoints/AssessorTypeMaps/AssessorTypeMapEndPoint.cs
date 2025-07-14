using Pms360.Application.Features.AssessorTypeMaps.Queries;

namespace Pms360.API.EndPoints.AssessorTypeMaps;

public class AssessorTypeMapEndPoint : EndPointGroupBase
{
    private const string RoutePrefix = "api/v1/pms360/assessorTypeMaMap";

    public override void Map(WebApplication app)
    {
        var group = app.MapGroup(RoutePrefix).WithTags("AssessorTypeMap").WithDescription("Works with Assessor Type Mapping Set Up !")
            .RequireAuthorization();

        group.MapPost("create", CreateAssessorTypeMap);
        group.MapGet("getAll", GetAssessorTypeMaps);
    }
    public async Task<IResult> CreateAssessorTypeMap(ISender sender, [AsParameters] CreateAssessorTypeMapCommand command)
    {
        var result = await sender.Send(command);
        if (result.IsSuccessful)
        {
            return Results.Ok(result);
        }
        return Results.BadRequest(result);
    }
    public async Task<IResult> GetAssessorTypeMaps(ISender sender)
    {
        var result = await sender.Send(new GetAssessorTypeMapQuery());
        if (result.IsSuccessful)
        {
            return Results.Ok(result);
        }
        return Results.BadRequest(result);
    }
}

namespace Pms360.API.EndPoints.AssessorTypes;

public class AssessorTypeEndPoint  : EndPointGroupBase
{
    private const string RoutePrefix = "api/v1/pms360/assessortype";

    public override void Map(WebApplication app)
    {
        var group = app.MapGroup(RoutePrefix).WithTags("PMSAssessorType").WithDescription("Works with Assessor Types like Self-Assess, Supervisor Assess,Peer Asses, Colleague Assess,Stakeholder Assess etc.")
            .RequireAuthorization();

        group.MapPost("create", CreateAssessorType);
        group.MapGet("getAll", GetAssessorTypes);

    }
    public async Task<IResult> CreateAssessorType(ISender sender, [AsParameters] CreateAssessorTypeCommand command)
    {
        var result = await sender.Send(command);
        if (result.IsSuccessful)
        {
            return Results.Ok(result);
        }
        return Results.BadRequest(result);

    }
    public async Task<IResult> GetAssessorTypes(ISender sender)
    {
        var result = await sender.Send(new GetAssessorTypeQuery());
        if (result.IsSuccessful)
        {
            return Results.Ok(result);
        }
        return Results.BadRequest(result);
    }
}

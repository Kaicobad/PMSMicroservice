namespace Pms360.API.EndPoints.PMSCycles;

public class PMSCycleEndPoint : EndPointGroupBase
{
    private const string RoutePrefix = "api/v1/pms360/pmscycle";
    public override void Map(WebApplication app)
    {
        var group = app.MapGroup(RoutePrefix).WithTags("PMSCycle").WithDescription("Used TO Create PMS-360 Cycle") ;
        group.MapPost("create", CreatePMSCycle);
        group.MapGet("get", GetPmsCycleByTypeAndDurationWithPagination);
    }
    public async Task<IResult> CreatePMSCycle(ISender sender, [AsParameters] CreatePmsCycleCommand command)
    {
        var result = await sender.Send(command);
        if (result.IsSuccessful)
        {
            return Results.Ok(result);
        }
        return Results.BadRequest(result);
    }
    public async Task<IResult> GetPmsCycleByTypeAndDurationWithPagination(ISender sender, [AsParameters] GetPmsCyclePaginatedQuery query)
    {
        var result = await sender.Send(query);
        if (result.IsSuccessful)
        {
            return Results.Ok(result);
        }
        return Results.BadRequest(result);

    }
}

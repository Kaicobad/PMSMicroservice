namespace Pms360.API.EndPoints.PMSDurationTypes;

public class PMSDurationTypeEndPoint : EndPointGroupBase
{
    private const string RoutePrefix = "api/v1/pms360/pmsdurationtype";
    public override void Map(WebApplication app)
    {
        var group = app.MapGroup(RoutePrefix).WithTags("PMSDurationType").WithDescription("TO Fix a Duration Types like eg:half-yearly,yearly")
            .RequireAuthorization();
        group.MapPost("create", CreatePMSDurationType);
        group.MapGet("getAll", GetPmsDurationTypes);
    }
    public async Task<IResult> CreatePMSDurationType(ISender sender, [AsParameters] CreatePmsDurationTypeCommand command)
    {
        var result = await sender.Send(command);
        if (result.IsSuccessful)
        {
            return Results.Ok(result);
        }
        return Results.BadRequest(result);
    }
    public async Task<IResult> GetPmsDurationTypes(ISender sender)
    {
        var result = await sender.Send(new GetPmsDurationTypeQuery());
        if (result.IsSuccessful)
        {
            return Results.Ok(result);
        }
        return Results.BadRequest(result);
    }
}

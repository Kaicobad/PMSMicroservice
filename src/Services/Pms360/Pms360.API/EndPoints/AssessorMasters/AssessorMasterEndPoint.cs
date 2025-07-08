namespace Pms360.API.EndPoints.AssessorMasters;

public class AssessorMasterEndPoint : EndPointGroupBase
{
    private const string RoutePrefix = "api/v1/pms360/assessorMaster";

    public override void Map(WebApplication app)
    {
        var group = app.MapGroup(RoutePrefix).WithTags("AssessorMaster").WithDescription("Works with Assessor Master Set Up !")
            .RequireAuthorization();

        group.MapPost("create", CreateAssessorMaster);
    }
    public async Task<IResult> CreateAssessorMaster(ISender sender, [AsParameters] CreateAssessorMasterCommand command)
    {
        var result = await sender.Send(command);
        if (result.IsSuccessful)
        {
            return Results.Ok(result);
        }
        return Results.BadRequest(result);

    }
}

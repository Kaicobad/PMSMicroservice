using MediatR;
using Pms360.API.Infrastructure;
using Pms360.Application.Features.PMSTypes.Commands;
using Pms360.Application.Features.PMSTypes.Queries;
using Pms360.Application.Response;

namespace Pms360.API.EndPoints.PMSTypes;

public class PMSType : EndPointGroupBase
{
    private const string RoutePrefix = "api/v1/pms360/pmstype";

    public override void Map(WebApplication app)
    {
        var group = app.MapGroup(RoutePrefix).WithTags("PMSType"); ;
        group.MapPost("", CreatePMSType);       
        group.MapGet("", GetPmsTypes);
    }
    public async Task<IResult> CreatePMSType(ISender sender, [AsParameters] CreatePmsTypeCommand command)
    {
        var result = await sender.Send(command);
        return Results.Ok(result);
    }
    public async Task<IResult> GetPmsTypes(ISender sender)
    {
        var result = await sender.Send(new GetPmsTypeQuery());
        return Results.Ok(result);
    }
}

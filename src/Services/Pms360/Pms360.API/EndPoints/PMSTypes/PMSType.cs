namespace Pms360.API.EndPoints.PMSTypes;

public class PMSType : EndPointGroupBase
{
    private const string RoutePrefix = "api/v1/pms360/pmstype";

    public override void Map(WebApplication app)
    {
        var group = app.MapGroup(RoutePrefix).WithTags("PMSType"); ;
        group.MapPost("create", CreatePMSType);
        group.MapPut("update", UpdatePMSType);
        group.MapGet("getAll", GetPmsTypes);
        group.MapGet("getAllNoFilter", GetPmsTypesNoFilter);
        group.MapGet("getAllPaginated", GetPmsTypesWithPagination);
        group.MapGet("getById/{typeId}", GetPmsTypeById);
        group.MapDelete("delete/{typeId}", DeletePmsType);
    }
    public async Task<IResult> CreatePMSType(ISender sender, [AsParameters] CreatePmsTypeCommand command)
    {
        var result = await sender.Send(command);
        if (result.IsSuccessful)
        {
            return Results.Ok(result);
        }
        return Results.BadRequest(result);
        
    }
    public async Task<IResult> UpdatePMSType(ISender sender, [AsParameters] UpdatePmsTypeCommand command)
    {
        var result = await sender.Send(command);
        if (result.IsSuccessful)
        {
            return Results.Ok(result);
        }
        return Results.BadRequest(result);
    }
    public async Task<IResult> GetPmsTypes(ISender sender)
    {
        var result = await sender.Send(new GetPmsTypeQuery());
        if (result.IsSuccessful)
        {
            return Results.Ok(result);
        }
        return Results.BadRequest(result);
    }
    public async Task<IResult> GetPmsTypesNoFilter(ISender sender)
    {
        var result = await sender.Send(new GetPmsTypeQueryNoFilter());
        if (result.IsSuccessful)
        {
            return Results.Ok(result);
        }
        return Results.BadRequest(result);
        
    }
    public async Task<IResult> GetPmsTypesWithPagination(ISender sender, [AsParameters] GetPmsTypePaginatedQuery query)
    {
        var result = await sender.Send(query);
        if (result.IsSuccessful)
        {
            return Results.Ok(result);
        }
        return Results.BadRequest(result);

    }
    public async Task<IResult> GetPmsTypeById(ISender sender, Guid typeId)
    {
        var result = await sender.Send(new GetPmsTypeByIdQuery { TypeId = typeId });
        if (result.IsSuccessful)
        {
            return Results.Ok(result);
        }
        return Results.BadRequest(result);
        
    }
    public async Task<IResult> DeletePmsType(ISender sender, Guid typeId)
    {
        var result = await sender.Send(new DeletePmsTypeCommand { TypeId = typeId });
        if (result.IsSuccessful)
        {
            return Results.Ok(result);
        }
        return Results.BadRequest(result);
    }
}

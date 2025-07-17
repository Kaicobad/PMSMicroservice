namespace Pms360.API.EndPoints.CommonDepartments;

public class CommonDepartmentEndPoint : EndPointGroupBase
{
    private const string RoutePrefix = "api/v1/pms360/department";
    public override void Map(WebApplication app)
    {
        var group = app.MapGroup(RoutePrefix).WithTags("CoreERPCommonDepartment").WithDescription("Works with retrieving the departments information")
            .RequireAuthorization();

        group.MapGet("getbyunit", GetCommonDepartmentByUnitId);
        group.MapGet("getAllAsync", GetCommonDepartments);
    }
    public async Task<IResult> GetCommonDepartmentByUnitId(ISender sender, int unitId)
    {
        var result = await sender.Send(new GetCommonDepartmentByUnitIdQuery { UnitId = unitId });
        if (result.IsSuccessful)
        {
            return Results.Ok(result);
        }
        return Results.BadRequest(result);

    }
    public async Task<IResult> GetCommonDepartments(ISender sender)
    {
        var result = await sender.Send(new GetCommonDepartmentQuery());
        if (result.IsSuccessful)
        {
            return Results.Ok(result);
        }
        return Results.BadRequest(result);
    }
}

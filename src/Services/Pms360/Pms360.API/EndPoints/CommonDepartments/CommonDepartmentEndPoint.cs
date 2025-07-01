namespace Pms360.API.EndPoints.CommonDepartments;

public class CommonDepartmentEndPoint : EndPointGroupBase
{
    private const string RoutePrefix = "api/v1/pms360/department";
    public override void Map(WebApplication app)
    {
        var group = app.MapGroup(RoutePrefix).WithTags("CoreERPCommonDepartment").WithDescription("Works with retriving the departments informations")
            .RequireAuthorization();

        group.MapGet("getbyunit", GetCommonDepartmentByUnitId);
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
}

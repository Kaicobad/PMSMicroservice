namespace Pms360.API.EndPoints.CommonSections;

public class CommonSectionEndPoint : EndPointGroupBase
{
    private const string RoutePrefix = "api/v1/pms360/sections";

    public override void Map(WebApplication app)
    {
        var group = app.MapGroup(RoutePrefix).WithTags("CoreERPCommonSection").WithDescription("Works with retrieve Section Information")
            .RequireAuthorization();

       
        //group.MapGet("getAll", GetPmsTypes);
        group.MapGet("getbyunitanddept", GetCommonSectionByUnitAndDepartment);;
    }
    public async Task<IResult> GetCommonSectionByUnitAndDepartment(ISender sender,  [AsParameters] GetCommonSectionByUnitIdAndDeptIdQuery query)
    {
        var result = await sender.Send(query);

        if (result.IsSuccessful)
        {
            return Results.Ok(result);
        }
        return Results.BadRequest(result);

    }
}

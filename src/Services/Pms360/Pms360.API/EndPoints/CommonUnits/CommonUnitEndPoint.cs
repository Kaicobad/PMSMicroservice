namespace Pms360.API.EndPoints.CommonUnits;

public class CommonUnitEndPoint : EndPointGroupBase
{
    private const string RoutePrefix = "api/v1/pms360/units";
    public override void Map(WebApplication app)
    {
        var group = app.MapGroup(RoutePrefix).WithTags("CoreERPCommonUnit").WithDescription("Works with retriving Unit Information")
           .RequireAuthorization();
        group.MapGet("getall", GetCommonUnits);
        group.MapGet("getbycompanyId", GetCommonUnitsByCompanyId);
    }
    public async Task<IResult> GetCommonUnitsByCompanyId(ISender sender, int companyId)
    {
        var result = await sender.Send(new GetCommonUnitByCompanyIdQuery { CompanyId = companyId });
        if (result.IsSuccessful)
        {
            return Results.Ok(result);
        }
        return Results.BadRequest(result);

    }
    public async Task<IResult> GetCommonUnits(ISender sender)
    {
        var result = await sender.Send(new GetCommonUnitQuery());
        if (result.IsSuccessful)
        {
            return Results.Ok(result);
        }
        return Results.BadRequest(result);

    }
}

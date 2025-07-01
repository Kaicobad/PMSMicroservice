namespace Pms360.API.EndPoints.CommonCompanies;

public class CommonCompaniesEndPoint : EndPointGroupBase
{
    private const string RoutePrefix = "api/v1/pms360/companies";
    public override void Map(WebApplication app)
    {
        var group = app.MapGroup(RoutePrefix).WithTags("CoreERPCompany").WithDescription("Works with retriving Company information");
           //.RequireAuthorization();
        group.MapGet("getAll", GetCommonCompanies);
        //group.MapDelete("getById", DeletePmsType);
    }
    public async Task<IResult> GetCommonCompanies(ISender sender)
    {
        var result = await sender.Send(new GetCommonCompanyQuery());
        if (result.IsSuccessful)
        {
            return Results.Ok(result);
        }
        return Results.BadRequest(result);
    }
}

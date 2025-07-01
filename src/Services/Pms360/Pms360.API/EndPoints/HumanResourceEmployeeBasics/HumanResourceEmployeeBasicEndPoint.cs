
using Pms360.Application.Features.HumanResourceEmployeeBasics.Queries;

namespace Pms360.API.EndPoints.HumanResourceEmployeeBasics;

public class HumanResourceEmployeeBasicEndPoint : EndPointGroupBase
{
    private const string RoutePrefix = "api/v1/pms360/employeebasic";
    public override void Map(WebApplication app)
    {
        var group = app.MapGroup(RoutePrefix).WithTags("CoreERPEmployeeBasic").WithDescription("Informations from CoreErp / HRM");
            //.RequireAuthorization();

        group.MapGet("getbyempcode", GetHumanResourceEmployeeBasicByEmpCode);
        group.MapGet("getbydepartment", GetHumanResourceEmployeeBasicByDepartment);
    }
    public async Task<IResult> GetHumanResourceEmployeeBasicByEmpCode(ISender sender, string empCode)
    {
        var result = await sender.Send(new GetHumanResourceEmployeeBasicByEmpCodeQuery { EmpCode = empCode });
        if (result.IsSuccessful)
        {
            return Results.Ok(result);
        }
        return Results.BadRequest(result);

    }
    public async Task<IResult> GetHumanResourceEmployeeBasicByDepartment(ISender sender, int departmentId)
    {
        var result = await sender.Send(new GetHumanResourceEmployeeBasicByDepartmentIdQuery { DepartmentId = departmentId });
        if (result.IsSuccessful)
        {
            return Results.Ok(result);
        }
        return Results.BadRequest(result);

    }
}


namespace Pms360.Application.Features.CommonDepartments.Queries;
public class GetCommonDepartmentByUnitIdQuery : IRequest<IResponse<List<CommonDepartment>>>
{
    public int UnitId { get; set; }

}
public class GetCommonDepartmentByUnitIdQueryHandler(ICommonDepartmentService service) : IRequestHandler<GetCommonDepartmentByUnitIdQuery, IResponse<List<CommonDepartment>>>
{
    private readonly ICommonDepartmentService _service = service;

    public async Task<IResponse<List<CommonDepartment>>> Handle(GetCommonDepartmentByUnitIdQuery request, CancellationToken cancellationToken)
    {
        var departmentsByUnit = await _service.GetByUnitIdAsync(request.UnitId,cancellationToken);
        if (departmentsByUnit.Count>0)
        {
            return Response<List<CommonDepartment>>.Success(departmentsByUnit);
        }
        return Response<List<CommonDepartment>>.Fail("Department doesn't exists in this unit !");
    }
}

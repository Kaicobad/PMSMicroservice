using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pms360.Application.Response;

namespace Pms360.Application.Features.HumanResourceEmployeeBasics.Queries;
public class GetHumanResourceEmployeeBasicByDepartmentIdQuery :IRequest<IResponse<List<HumanResourceEmployeeBasic>>>
{
    public int DepartmentId { get; set; }
}
public class GetHumanResourceEmployeeBasicByDepartmentIdQueryHandler(IHumanResourceEmployeeBasicService service) : IRequestHandler<GetHumanResourceEmployeeBasicByDepartmentIdQuery, IResponse<List<HumanResourceEmployeeBasic>>>
{
    private readonly IHumanResourceEmployeeBasicService _service = service;

    public async Task<IResponse<List<HumanResourceEmployeeBasic>>> Handle(GetHumanResourceEmployeeBasicByDepartmentIdQuery request, CancellationToken cancellationToken)
    {
        var employees = await _service.GetByDepartmentAsync(request.DepartmentId, cancellationToken);

        return employees.Count > 0
           ? Response<List<HumanResourceEmployeeBasic>>.Success(data: employees)
           : Response<List<HumanResourceEmployeeBasic>>.Fail(message: "There is no Employee Exists In This Departments");
    }
}

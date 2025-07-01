using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pms360.Application.Features.CommonUnits.Queries;
public class GetCommonUnitByCompanyIdQuery : IRequest<IResponse<List<CommonUnit>>> , IValidatable
{
    public int CompanyId { get; set; }
}
public class GetCommonUnitByCompanyIdQueryHandler(ICommonUnitService service) : IRequestHandler<GetCommonUnitByCompanyIdQuery, IResponse<List<CommonUnit>>>
{
    private readonly ICommonUnitService _service = service;

    public async Task<IResponse<List<CommonUnit>>> Handle(GetCommonUnitByCompanyIdQuery request, CancellationToken cancellationToken)
    {
        var units = await _service.GetByCompanyId(request.CompanyId, cancellationToken);
        if (units.Count > 0)
        {
            return Response<List<CommonUnit>>.Success(units);
        }
        return Response<List<CommonUnit>>.Fail("Unit Dosen't Exists under this Company");
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pms360.Application.Features.CommonUnits.Queries;
public class GetCommonUnitQuery : IRequest<IResponse<List<CommonUnit>>> , IValidatable
{
}
public class GetCommonUnitQueryHandler(ICommonUnitService service) : IRequestHandler<GetCommonUnitQuery, IResponse<List<CommonUnit>>>
{
    private readonly ICommonUnitService _service = service;

    public async Task<IResponse<List<CommonUnit>>> Handle(GetCommonUnitQuery request, CancellationToken cancellationToken)
    {
        var response = await _service.GetAllAsync(cancellationToken);

        return response.Count > 0
            ? Response<List<CommonUnit>>.Success(data: response)
            : Response<List<CommonUnit>>.Fail(message: "There is no Unit Exists");
    }
}

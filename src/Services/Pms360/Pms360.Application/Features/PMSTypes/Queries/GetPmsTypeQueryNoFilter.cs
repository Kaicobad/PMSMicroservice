using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pms360.Application.Features.PMSTypes.Queries;
public class GetPmsTypeQueryNoFilter : IRequest<IResponse<List<Pmstype>>>
{
}
public class GetPmsTypeQueryNoFilterHandler(IPMSTypesService service) : IRequestHandler<GetPmsTypeQueryNoFilter, IResponse<List<Pmstype>>>
{
    private readonly IPMSTypesService _service = service;

    public async Task<IResponse<List<Pmstype>>> Handle(GetPmsTypeQueryNoFilter request, CancellationToken cancellationToken)
    {
        var response = await _service.GetAllNoFilter(cancellationToken);

        return response.Count > 0
            ? Response<List<Pmstype>>.Success(data: response)
            : Response<List<Pmstype>>.Fail(message: "There is no Type Exists");
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pms360.Application.Features.PMSTypes.Queries;
public class GetPmsTypeQueryNoFilter : IRequest<IResponse<List<PMSType>>>
{
}
public class GetPmsTypeQueryNoFilterHandler(IPMSTypesService service) : IRequestHandler<GetPmsTypeQueryNoFilter, IResponse<List<PMSType>>>
{
    private readonly IPMSTypesService _service = service;

    public async Task<IResponse<List<PMSType>>> Handle(GetPmsTypeQueryNoFilter request, CancellationToken cancellationToken)
    {
        var response = await _service.GetAllNoFilter(cancellationToken);

        return response.Count > 0
            ? Response<List<PMSType>>.Success(data: response)
            : Response<List<PMSType>>.Fail(message: "There is no Type Exists");
    }
}

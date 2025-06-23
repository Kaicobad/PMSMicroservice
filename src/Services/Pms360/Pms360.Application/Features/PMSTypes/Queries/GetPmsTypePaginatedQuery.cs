using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pms360.Application.Features.PMSTypes.Queries;
public class GetPmsTypePaginatedQuery : IRequest<IResponse<PaginatedList<PMSType>>> , IValidatable
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; } = 10;
}
public class GetPmsTypePaginatedQueryHandler(IPMSTypesService service) : IRequestHandler<GetPmsTypePaginatedQuery, IResponse<PaginatedList<PMSType>>>
{
    private readonly IPMSTypesService _service = service;

    public async Task<IResponse<PaginatedList<PMSType>>> Handle(GetPmsTypePaginatedQuery request, CancellationToken cancellationToken)
    {
        var response = await _service.GetAllWithPagination(request.PageNumber, request.PageSize, cancellationToken);
        if (response != null && response.Items.Any())
        {
            return Response<PaginatedList<PMSType>>.Success(response);
        }

        return Response<PaginatedList<PMSType>>.Fail("Types does not exist!");
    }
}

namespace Pms360.Application.Features.PMSTypes.Queries;
public class GetPmsTypePaginatedQuery : IRequest<IResponse<PaginatedList<Pmstype>>> , IValidatable
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; } = 10;
}
public class GetPmsTypePaginatedQueryHandler(IPMSTypesService service) : IRequestHandler<GetPmsTypePaginatedQuery, IResponse<PaginatedList<Pmstype>>>
{
    private readonly IPMSTypesService _service = service;

    public async Task<IResponse<PaginatedList<Pmstype>>> Handle(GetPmsTypePaginatedQuery request, CancellationToken cancellationToken)
    {
        var response = await _service.GetAllWithPagination(request.PageNumber, request.PageSize, cancellationToken);
        if (response != null && response.Items.Any())
        {
            return Response<PaginatedList<Pmstype>>.Success(response);
        }

        return Response<PaginatedList<Pmstype>>.Fail("Types does not exist!");
    }
}

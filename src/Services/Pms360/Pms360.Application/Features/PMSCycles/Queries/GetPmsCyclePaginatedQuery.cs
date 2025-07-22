namespace Pms360.Application.Features.PMSCycles.Queries;
public class GetPmsCyclePaginatedQuery : IRequest<IResponse<PaginatedList<Pmscycle>>>, IValidatable
{
    public Guid PMSTypeId { get; set; }
    public Guid PMSDurationTypeId { get; set; }
    public int PageNumber { get; set; }
    public int PageSize { get; set; } = 10;
}
public class GetPmsCyclePaginatedQueryHandler(IPMSCycleService service) : IRequestHandler<GetPmsCyclePaginatedQuery, IResponse<PaginatedList<Pmscycle>>>
{
    private readonly IPMSCycleService _service = service;

    public async Task<IResponse<PaginatedList<Pmscycle>>> Handle(GetPmsCyclePaginatedQuery request, CancellationToken cancellationToken)
    {
        var response = await _service.GetByTypeAndDurationAsync(request.PMSTypeId,request.PMSDurationTypeId,request.PageNumber, request.PageSize, cancellationToken);
        if (response != null && response.Items.Any())
        {
            return Response<PaginatedList<Pmscycle>>.Success(response);
        }

        return Response<PaginatedList<Pmscycle>>.Fail("PMS Cycle does not exist!");
    }
}

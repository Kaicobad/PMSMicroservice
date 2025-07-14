
namespace Pms360.Application.Features.AssessorMasters.Queries;
public class GetAssessorMasterByMasterIdPaginatedQuery : IRequest<IResponse<PaginatedList<AssessorMaster>>>, IValidatable
{
    public Guid AssessorMasterId { get; set; }
    public int PageNumber { get; set; }
    public int PageSize { get; set; } = 10;
}
public class GetAssessorMasterByMasterIdPaginatedQueryHandler(IAssessorMasterService service, IMapper mapper) : IRequestHandler<GetAssessorMasterByMasterIdPaginatedQuery, IResponse<PaginatedList<AssessorMaster>>>
{
    private readonly IAssessorMasterService _service = service;
    private readonly IMapper _mapper = mapper;

    public async Task<IResponse<PaginatedList<AssessorMaster>>> Handle(GetAssessorMasterByMasterIdPaginatedQuery request, CancellationToken cancellationToken)
    {
        var response = await _service.GetByAssessorMaserIdWithPagination(request.AssessorMasterId,request.PageNumber, request.PageSize, cancellationToken);
        if (response != null && response.Items.Any())
        {
            return Response<PaginatedList<AssessorMaster>>.Success(response);
        }

        return Response<PaginatedList<AssessorMaster>>.Fail("Assessor Master Data's does not exist!");
    }
}

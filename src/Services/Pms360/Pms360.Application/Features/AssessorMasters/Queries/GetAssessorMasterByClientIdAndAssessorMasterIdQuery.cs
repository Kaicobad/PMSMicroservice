namespace Pms360.Application.Features.AssessorMasters.Queries;
public class GetAssessorMasterByClientIdAndAssessorMasterIdQuery  : IRequest<IResponse<AssessorMaster>>,IValidatable
{
    public Guid ClientId { get; set; }
    public Guid AssessorMasterId { get; set; }
}
public class GetAssessorMasterByClientIdAndAssessorMasterIdQueryHandler(IAssessorMasterService service, IMapper mapper) : IRequestHandler<GetAssessorMasterByClientIdAndAssessorMasterIdQuery, IResponse<AssessorMaster>>
{
    private readonly IAssessorMasterService _service = service;
    private readonly IMapper _mapper = mapper;

    public async Task<IResponse<AssessorMaster>> Handle(GetAssessorMasterByClientIdAndAssessorMasterIdQuery request, CancellationToken cancellationToken)
    {
        var response = await _service.GetByClientIdAsync(request.ClientId,request.AssessorMasterId, cancellationToken);
        if (response != null)
        {
            return Response<AssessorMaster>.Success(data: response.Adapt<AssessorMaster>());
        }
        else
        {
            return Response<AssessorMaster>.Fail("Data Doesn't exists on Assessor master !");
        }
    }
}

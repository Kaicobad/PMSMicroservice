
namespace Pms360.Application.Features.AssessorMasters.Queries;
public class GetByAssessorMasterIdQuery : IRequest<IResponse<List<AssessorMasterDTO>>>
{
    public Guid AssessorMasterId { get; set; }
}
public class GetByAssessorMasterIdQueryHandler(IAssessorMasterService service) : IRequestHandler<GetByAssessorMasterIdQuery, IResponse<List<AssessorMasterDTO>>>
{
    private readonly IAssessorMasterService _service = service;

    public async Task<IResponse<List<AssessorMasterDTO>>> Handle(GetByAssessorMasterIdQuery request, CancellationToken cancellationToken)
    {
        var response = await _service.GetByAssessorMaserId(request.AssessorMasterId, cancellationToken);
        if (response.Count > 0)
        {
            return Response<List<AssessorMasterDTO>>.Success(data: response);
        }
        else
        {
            return Response<List<AssessorMasterDTO>>.Fail("Assessor Master Does Not Exists !");
        }
    }
}

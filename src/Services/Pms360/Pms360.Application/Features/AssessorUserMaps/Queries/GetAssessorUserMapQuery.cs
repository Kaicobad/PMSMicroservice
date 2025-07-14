namespace Pms360.Application.Features.AssessorUserMaps.Queries;
public class GetAssessorUserMapQuery : IRequest<IResponse>
{
}
public class GetAssessorUserMapQueryHandler(IAssessorUserMapService service) : IRequestHandler<GetAssessorUserMapQuery, IResponse>
{
    private readonly IAssessorUserMapService _service = service;

    public async Task<IResponse> Handle(GetAssessorUserMapQuery request, CancellationToken cancellationToken)
    {
        var response = await _service.GetAllAsync(cancellationToken);

        return response.Count > 0
            ? Response<List<AssessorUserMap>>.Success(data: response)
            : Response<List<AssessorUserMap>>.Fail(message: "There is no Assessor User Map Exists");
    }
}

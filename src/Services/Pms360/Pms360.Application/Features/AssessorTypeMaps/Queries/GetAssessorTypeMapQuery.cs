namespace Pms360.Application.Features.AssessorTypeMaps.Queries;
public class GetAssessorTypeMapQuery : IRequest<IResponse>
{
}
public class GetAssessorTypeMapQueryHandler(IAssessorTypeMapService service) : IRequestHandler<GetAssessorTypeMapQuery, IResponse>
{
    private readonly IAssessorTypeMapService _service = service;

    public async Task<IResponse> Handle(GetAssessorTypeMapQuery request, CancellationToken cancellationToken)
    {
        var response = await _service.GetAllAsync(cancellationToken);

        return response.Count > 0
            ? Response<List<AssessorTypeMap>>.Success(data: response)
            : Response<List<AssessorTypeMap>>.Fail(message: "There is no Assessor Type Map Exists");
    }
}

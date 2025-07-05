namespace Pms360.Application.Features.AssessorTypes.Queries;
public class GetAssessorTypeQuery : IRequest<IResponse<List<AssessorType>>>
{
}
public class GetAssessorTypeQueryHandler(IAssessorTypeService service) : IRequestHandler<GetAssessorTypeQuery, IResponse<List<AssessorType>>>
{
    private readonly IAssessorTypeService _service = service;

    public async Task<IResponse<List<AssessorType>>> Handle(GetAssessorTypeQuery request, CancellationToken cancellationToken)
    {
        var response = await _service.GetAll(cancellationToken);

        return response.Count > 0
            ? Response<List<AssessorType>>.Success(data: response)
            : Response<List<AssessorType>>.Fail(message: "There is no Assessor Type Exists !");
    }
}


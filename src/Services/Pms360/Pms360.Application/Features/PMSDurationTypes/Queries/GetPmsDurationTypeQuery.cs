namespace Pms360.Application.Features.PMSDurationTypes.Queries;
public class GetPmsDurationTypeQuery : IRequest<IResponse<List<PMSDurationType>>>
{
}

public class GetPmsDurationTypeQueryHandler(IPMSDurationTypeService service) : IRequestHandler<GetPmsDurationTypeQuery, IResponse<List<PMSDurationType>>>
{
    private readonly IPMSDurationTypeService _service = service;

    public async Task<IResponse<List<PMSDurationType>>> Handle(GetPmsDurationTypeQuery request, CancellationToken cancellationToken)
    {
        var response = await _service.GetAll(cancellationToken);
        return response.Count > 0
         ? Response<List<PMSDurationType>>.Success(data: response)
         : Response<List<PMSDurationType>>.Fail(message: "There is no Type Exists");
    }
}

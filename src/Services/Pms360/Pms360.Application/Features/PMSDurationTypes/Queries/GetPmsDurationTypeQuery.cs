namespace Pms360.Application.Features.PMSDurationTypes.Queries;
public class GetPmsDurationTypeQuery : IRequest<IResponse<List<PmsdurationType>>>
{
}

public class GetPmsDurationTypeQueryHandler(IPMSDurationTypeService service) : IRequestHandler<GetPmsDurationTypeQuery, IResponse<List<PmsdurationType>>>
{
    private readonly IPMSDurationTypeService _service = service;

    public async Task<IResponse<List<PmsdurationType>>> Handle(GetPmsDurationTypeQuery request, CancellationToken cancellationToken)
    {
        var response = await _service.GetAll(cancellationToken);
        return response.Count > 0
         ? Response<List<PmsdurationType>>.Success(data: response)
         : Response<List<PmsdurationType>>.Fail(message: "There is no Type Exists");
    }
}

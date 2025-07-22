
namespace Pms360.Application.Features.PMSTypes.Queries;
public class GetPmsTypeQuery :IRequest<IResponse<List<Pmstype>>>
{
}
public class GetPmsTypesQueryHandler(IPMSTypesService service) : IRequestHandler<GetPmsTypeQuery, IResponse<List<Pmstype>>>
{
    private readonly IPMSTypesService _service = service;

    public async Task<IResponse<List<Pmstype>>> Handle(GetPmsTypeQuery request, CancellationToken cancellationToken)
    {
        var response = await _service.GetAll(cancellationToken);

        return response.Count > 0
            ? Response<List<Pmstype>>.Success(data: response)
            : Response<List<Pmstype>>.Fail(message: "There is no Type Exists");
    }
}

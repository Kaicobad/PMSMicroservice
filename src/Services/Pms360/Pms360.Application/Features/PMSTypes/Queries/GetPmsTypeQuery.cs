
namespace Pms360.Application.Features.PMSTypes.Queries;
public class GetPmsTypeQuery :IRequest<Response<List<PMSType>>>
{
}
public class GetPmsTypesQueryHandler(IPMSTypesService service) : IRequestHandler<GetPmsTypeQuery, Response<List<PMSType>>>
{
    private readonly IPMSTypesService _service = service;

    public async Task<Response<List<PMSType>>> Handle(GetPmsTypeQuery request, CancellationToken cancellationToken)
    {
        var response = await _service.GetAll(cancellationToken);

        return response.Count > 0
            ? Response<List<PMSType>>.Success(data: response)
            : Response<List<PMSType>>.Fail(message: "There is no Type Exists");
    }
}

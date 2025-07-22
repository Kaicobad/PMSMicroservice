
namespace Pms360.Application.Features.PMSTypes.Queries;
public class GetPmsTypeByIdQuery : IRequest<IResponse<Pmstype>>, IValidatable
{
    public Guid TypeId { get; set; }
}
public class GetPmsTypeByIdQueryHandler(IPMSTypesService service) : IRequestHandler<GetPmsTypeByIdQuery, IResponse<Pmstype>>
{
    private readonly IPMSTypesService _service = service;

    public async Task<IResponse<Pmstype>> Handle(GetPmsTypeByIdQuery request, CancellationToken cancellationToken)
    {
        var response = await _service.GetByIdAsync(request.TypeId,cancellationToken);
        if (response != null)
        {
            return Response<Pmstype>.Success(data: response.Adapt<Pmstype>());
        }
        else
        {
            return Response<Pmstype>.Fail("Type Does Not Exists !");
        }
        
    }
}

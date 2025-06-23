
namespace Pms360.Application.Features.PMSTypes.Queries;
public class GetPmsTypeByIdQuery : IRequest<IResponse<PMSType>>, IValidatable
{
    public Guid TypeId { get; set; }
}
public class GetPmsTypeByIdQueryHandler(IPMSTypesService service) : IRequestHandler<GetPmsTypeByIdQuery, IResponse<PMSType>>
{
    private readonly IPMSTypesService _service = service;

    public async Task<IResponse<PMSType>> Handle(GetPmsTypeByIdQuery request, CancellationToken cancellationToken)
    {
        var response = await _service.GetByIdAsync(request.TypeId,cancellationToken);
        if (response != null)
        {
            return Response<PMSType>.Success(data: response.Adapt<PMSType>());
        }
        else
        {
            return Response<PMSType>.Fail("Type Does Not Exists !");
        }
        
    }
}

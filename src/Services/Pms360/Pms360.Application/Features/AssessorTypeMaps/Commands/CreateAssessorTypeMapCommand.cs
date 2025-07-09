
namespace Pms360.Application.Features.AssessorTypeMaps.Commands;
public class CreateAssessorTypeMapCommand  : IRequest<IResponse>, IValidatable
{
    public CreateAssessorTypeMapRequest CreateAssessorTypeMap { get; set; }
}
public class CreateAssessorTypeMapCommandHandler(IAssessorTypeMapService service) : IRequestHandler<CreateAssessorTypeMapCommand, IResponse>
{
    private readonly IAssessorTypeMapService _service = service;

    public async Task<IResponse> Handle(CreateAssessorTypeMapCommand request, CancellationToken cancellationToken)
    {
        var assessorTypeMap = request.CreateAssessorTypeMap.Adapt<AssessorTypeMap>();
        var assessorTypeMapId = await _service.CreateAsync(assessorTypeMap, cancellationToken);

        return Response<Guid>.Success(data: assessorTypeMapId, message: "Assessor Type Mapped Successfully !");
    }
}

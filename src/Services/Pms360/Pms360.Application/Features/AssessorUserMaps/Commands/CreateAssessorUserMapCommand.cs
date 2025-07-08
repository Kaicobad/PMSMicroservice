namespace Pms360.Application.Features.AssessorUserMaps.Commands;
public class CreateAssessorUserMapCommand : IRequest<IResponse>, IValidatable
{
    public CreateAssessorUserMapRequest CreateAssessorUserMap { get; set; }
}
public class CreateAssessorUserMapCommandHandler(IAssessorUserMapService service) : IRequestHandler<CreateAssessorUserMapCommand, IResponse>
{
    private readonly IAssessorUserMapService _service = service;

    public async Task<IResponse> Handle(CreateAssessorUserMapCommand request, CancellationToken cancellationToken)
    {
        var assessorUserMap = request.CreateAssessorUserMap.Adapt<AssessorUserMap>();
        var assessorUserMapId = await _service.CreateAsync(assessorUserMap, cancellationToken);

        return Response<Guid>.Success(data: assessorUserMapId, message: "Assessor User Mapped Successfully !");
    }
}


namespace Pms360.Application.Features.AssessorTypes.Commands;
public class CreateAssessorTypeCommand : IRequest<IResponse>, IValidatable
{
    public CreateAssessorTypeRequest CreateAssessorType { get; set; }
}
public class CreateAssessorTypeCommandHandler(IAssessorTypeService service) : IRequestHandler<CreateAssessorTypeCommand, IResponse>
{
    private readonly IAssessorTypeService _service = service;

    public async Task<IResponse> Handle(CreateAssessorTypeCommand request, CancellationToken cancellationToken)
    {
        var assessorType = request.CreateAssessorType.Adapt<AssessorType>();
        var assessorTypeId = await _service.CreateAsync(assessorType, cancellationToken);

        return Response<Guid>.Success(data: assessorTypeId, message: "Assessor Type Created Successfully");
    }
}

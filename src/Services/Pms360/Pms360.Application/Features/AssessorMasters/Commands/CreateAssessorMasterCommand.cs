namespace Pms360.Application.Features.AssessorMasters.Commands;
public class CreateAssessorMasterCommand : IRequest<IResponse>, IValidatable
{
    public CreateAssessorMasterRequest CreateAssessorMaster { get; set; }
}
public class CreateAssessorMasterCommandHandler(IAssessorMasterService service) : IRequestHandler<CreateAssessorMasterCommand, IResponse>
{
    private readonly IAssessorMasterService _service = service;

    public async Task<IResponse> Handle(CreateAssessorMasterCommand request, CancellationToken cancellationToken)
    {
        var assessorMaster = request.CreateAssessorMaster.Adapt<AssessorMaster>();
        var assessorMasterId = await _service.CreateAsync(assessorMaster, cancellationToken);

        return Response<Guid>.Success(data: assessorMasterId, message: "Assessor Master Created Successfully !");

    }
}

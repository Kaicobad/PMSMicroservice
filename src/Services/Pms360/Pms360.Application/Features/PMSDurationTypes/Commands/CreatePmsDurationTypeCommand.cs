namespace Pms360.Application.Features.PMSDurationTypes.Commands;
public class CreatePmsDurationTypeCommand : IRequest<IResponse>
{
    public CreatePMSDurationTypeRequest CreatePmsDurationType { get; set; }
}
public class CreatePmsDurationTypeCommandHandler(IPMSDurationTypeService service) : IRequestHandler<CreatePmsDurationTypeCommand, IResponse>
{
    private readonly IPMSDurationTypeService _service = service;

    public async Task<IResponse> Handle(CreatePmsDurationTypeCommand request, CancellationToken cancellationToken)
    {
        var pmsDurationType = request.CreatePmsDurationType.Adapt<PMSDurationType>();
        var pmsDurationTypeId = await _service.CreateAsync(pmsDurationType, cancellationToken);

        return Response<Guid>.Success(data: pmsDurationTypeId, message: "PMS Duration Type Created Successfully !");
    }
}

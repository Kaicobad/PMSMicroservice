namespace Pms360.Application.Features.PMSTypes.Commands;
public class CreatePmsTypeCommand : IRequest<IResponse>, IValidatable
{
    public CreatePMSTypeRequest CreatePMSType { get; set; }
}
public class CreatePmsTypeCommandHandler(IPMSTypesService service) : IRequestHandler<CreatePmsTypeCommand, IResponse>
{
    private readonly IPMSTypesService _service = service;

    public async Task<IResponse> Handle(CreatePmsTypeCommand request, CancellationToken cancellationToken)
    {
        var pmsType = request.CreatePMSType.Adapt<PMSType>();
        var pmsTypeId = await _service.CreateAsync(pmsType,cancellationToken);

        return Response<Guid>.Success(data:pmsTypeId,message:"PMS Type Created Successfully");

    }
}

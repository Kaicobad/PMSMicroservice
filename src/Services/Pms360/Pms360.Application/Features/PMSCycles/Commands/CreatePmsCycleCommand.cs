namespace Pms360.Application.Features.PMSCycles.Commands;
public class CreatePmsCycleCommand : IRequest<IResponse>, IValidatable
{
    public CreatePMSCycleRequest CreatePmsCycle { get; set; }
}
public class CreatePmsCycleCommandHandler(IPMSCycleService service) : IRequestHandler<CreatePmsCycleCommand, IResponse>
{
    private readonly IPMSCycleService _service = service;

    public async Task<IResponse> Handle(CreatePmsCycleCommand request, CancellationToken cancellationToken)
    {
        var pmsCycle = request.CreatePmsCycle.Adapt<Pmscycle>();
        var pmsCycleId = await _service.CreateAsync(pmsCycle, cancellationToken);
        return Response<Guid>.Success(data: pmsCycleId, message: "PMS Cycle Created Successfully !");
    }
}

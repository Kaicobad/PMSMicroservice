namespace Pms360.Application.Features.PMSCycles.Validators;
public class CreatePmsCycleRequestValidator : AbstractValidator<CreatePMSCycleRequest>
{
    public CreatePmsCycleRequestValidator(IPMSTypesService typeService,IPMSDurationTypeService durationService)
    {
        RuleFor(request => request.PMSTypeId)
            .Cascade(CascadeMode.Stop)
            .MustAsync(async (id, ct) => await typeService.IsExistsAsync(id, ct))
            .WithMessage("This Type Doesn't  Exists !");
        RuleFor(request => request.PMSDurationTypeId)
            .Cascade(CascadeMode.Stop)
            .MustAsync(async (id, ct) => await durationService.IsExistsAsync(id, ct))
            .WithMessage("This Duration Type Doesn't Exists !");
    }
}

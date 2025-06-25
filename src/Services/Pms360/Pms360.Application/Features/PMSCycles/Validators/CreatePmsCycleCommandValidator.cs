namespace Pms360.Application.Features.PMSCycles.Validators;
public class CreatePmsCycleCommandValidator : AbstractValidator<CreatePmsCycleCommand>
{
    public CreatePmsCycleCommandValidator(IPMSTypesService typesService,IPMSDurationTypeService durationTypeService)
    {
        RuleFor(command => command.CreatePmsCycle)
           .SetValidator(new CreatePmsCycleRequestValidator(typesService, durationTypeService));
    }
}

namespace Pms360.Application.Features.PMSTypes.Validators;
public class CreatePmsTypeCommandValidator: AbstractValidator<CreatePmsTypeCommand>
{
    public CreatePmsTypeCommandValidator(IPMSTypesService service)
    {
        RuleFor(command => command.CreatePMSType)
            .SetValidator(new CreatePmsTypeRequestValidator(service));
    }
}

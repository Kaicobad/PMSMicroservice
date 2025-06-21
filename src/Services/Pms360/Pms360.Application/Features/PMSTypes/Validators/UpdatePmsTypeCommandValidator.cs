namespace Pms360.Application.Features.PMSTypes.Validators;
public class UpdatePmsTypeCommandValidator : AbstractValidator<UpdatePmsTypeCommand>
{
    public UpdatePmsTypeCommandValidator(IPMSTypesService service)
    {
        RuleFor(command => command.UpdatePmsType)
            .SetValidator(new UpdatePmsTypeRequestValidator(service));
    }
}

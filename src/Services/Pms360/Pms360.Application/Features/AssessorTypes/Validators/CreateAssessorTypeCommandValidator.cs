namespace Pms360.Application.Features.AssessorTypes.Validators;
public class CreateAssessorTypeCommandValidator :AbstractValidator<CreateAssessorTypeCommand>
{
    public CreateAssessorTypeCommandValidator(IAssessorTypeService service)
    {
        RuleFor(command => command.CreateAssessorType)
           .SetValidator(new CreateAssessorTypeRequestValidator(service));
    }
}

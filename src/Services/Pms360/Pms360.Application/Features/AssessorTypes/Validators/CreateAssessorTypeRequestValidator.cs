namespace Pms360.Application.Features.AssessorTypes.Validators;
public class CreateAssessorTypeRequestValidator : AbstractValidator<CreateAssessorTypeRequest>
{
    public CreateAssessorTypeRequestValidator(IAssessorTypeService service)
    {
        RuleFor(request => request.TypeName)
             .NotEmpty()
             .NotNull()
             .WithMessage("Assessor Type Name is required !");
        RuleFor(request => request.TypeName)
            .Cascade(CascadeMode.Stop)
            .MustAsync(async (name, ct) => !await service.IsNameExistsAsync(name, ct))
            .WithMessage("This Name Already Exists");
    }
}

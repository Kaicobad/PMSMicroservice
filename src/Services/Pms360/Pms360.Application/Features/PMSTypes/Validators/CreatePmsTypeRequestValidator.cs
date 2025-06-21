namespace Pms360.Application.Features.PMSTypes.Validators;
public class CreatePmsTypeRequestValidator : AbstractValidator<CreatePMSTypeRequest>
{
    public CreatePmsTypeRequestValidator(IPMSTypesService service)
    {
        RuleFor(request => request.Name)
             .NotEmpty()
             .NotNull()
             .WithMessage("PMS Type Name is required !");
        RuleFor(request => request.Name)
            .Cascade(CascadeMode.Stop)
            .MustAsync(async (name, ct) => !await service.IsNameExistsAsync(name, ct))
            .WithMessage("This Name Already Exists");
    }
   
}

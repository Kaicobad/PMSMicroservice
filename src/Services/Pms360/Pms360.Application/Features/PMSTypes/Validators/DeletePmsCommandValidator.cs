namespace Pms360.Application.Features.PMSTypes.Validators;
public class DeletePmsCommandValidator : AbstractValidator<DeletePmsTypeCommand>
{
    public DeletePmsCommandValidator(IPMSTypesService service)
    {
        RuleFor(x => x.TypeId)
           .NotNull()
           .NotEmpty()
           .WithMessage("TypeId Must Be Supplied")
           .MustAsync(async (TypeId, ct) => await service.IsExistsAsync(TypeId, ct))
           .WithMessage("Type Not Found To Delete !");
    }
}

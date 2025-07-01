using Pms360.Application.Features.CommonUnits;

namespace Pms360.Application.Features.CommonDepartments.Validators;
public class GetCommonDepartmentByUnitIdQueryValidator : AbstractValidator<GetCommonDepartmentByUnitIdQuery>
{
    public GetCommonDepartmentByUnitIdQueryValidator(ICommonUnitService service)
    {
        RuleFor(request => request.UnitId)
            .Cascade(CascadeMode.Stop)
            .MustAsync(async (UnitId, ct) => await service.IsExistsAsync(UnitId, ct))
            .WithMessage("This Unit Doesn't Exists");
    }
}

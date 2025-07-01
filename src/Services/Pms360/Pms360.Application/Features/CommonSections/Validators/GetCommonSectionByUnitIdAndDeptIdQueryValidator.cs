namespace Pms360.Application.Features.CommonSections.Validators;
public class GetCommonSectionByUnitIdAndDeptIdQueryValidator : AbstractValidator<GetCommonSectionByUnitIdAndDeptIdQuery>
{
    public GetCommonSectionByUnitIdAndDeptIdQueryValidator(ICommonUnitService unitService, ICommonDepartmentService deptService)
    {
        RuleFor(request => request.UnitId)
             .Cascade(CascadeMode.Stop)
             .MustAsync(async (UnitId, ct) => await unitService.IsExistsAsync(UnitId, ct))
             .WithMessage("This Unit Doesn't Exists");
        RuleFor(request => request.DepartmentId)
            .Cascade(CascadeMode.Stop)
            .MustAsync(async (DepartmentId, ct) => await deptService.IsExistsAsync(DepartmentId, ct))
            .WithMessage("This Department Doesn't Exists");
    }
}

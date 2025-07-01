namespace Pms360.Application.Features.HumanResourceEmployeeBasics.Validators;
public class GetHumanResourceEmployeeBasicByEmpCodeQueryValidator : AbstractValidator<GetHumanResourceEmployeeBasicByEmpCodeQuery>
{
    public GetHumanResourceEmployeeBasicByEmpCodeQueryValidator()
    {
        RuleFor(request => request.EmpCode)
           .NotNull()
           .WithMessage("Employee Code is required.");
        RuleFor(request => request.EmpCode)
            .NotEmpty()
            .WithMessage("Employee Code is required.");
    }
}

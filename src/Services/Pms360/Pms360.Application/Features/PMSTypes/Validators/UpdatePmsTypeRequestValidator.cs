using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pms360.Application.Features.PMSTypes.Validators;
public class UpdatePmsTypeRequestValidator : AbstractValidator<UpdatePMSTypeRequest>
{
    public UpdatePmsTypeRequestValidator(IPMSTypesService service)
    {
        RuleFor(request => request.TypeId)
            .NotNull()
            .WithMessage("TypeId is required.")
            .Must(id => id != Guid.Empty)
            .WithMessage("TypeId must not be empty.")
            .MustAsync(async (typeId, ct) => await service.IsExistsAsync(typeId, ct))
            .WithMessage("Type not found to update!");

        RuleFor(request => request.Name)
               .NotEmpty()
               .WithMessage("PMS Type Name is required!");
    }
}

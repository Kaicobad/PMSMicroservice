using Pms360.Domain.Entities;

namespace Pms360.Application.Features.PMSTypes.Commands;
public class UpdatePmsTypeCommand : IRequest<IResponse>,IValidatable
{
    public UpdatePMSTypeRequest UpdatePmsType { get; set; }
}

public class UpdatePmsTypeCommandHandler(IPMSTypesService service) : IRequestHandler<UpdatePmsTypeCommand, IResponse>
{
    private readonly IPMSTypesService _service = service;

    public async Task<IResponse> Handle(UpdatePmsTypeCommand request, CancellationToken cancellationToken)
    {
        var pmsType = request.UpdatePmsType.Adapt<Pmstype>();

        var updatePmsType = await _service.UpdateAsync(pmsType, cancellationToken);
        if (updatePmsType != null) 
        {
            return Response<Pmstype>.Success(data: updatePmsType, message: "PMS Type Updated Successfully");
        }
        return Response<Pmstype>.Fail(message: "Couldn't Update the Type");
       
    }
}

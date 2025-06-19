

namespace Pms360.Application.Features.PMSTypes.Commands;
public class DeletePmsTypeCommand : IRequest<IResponse>
{
    public Guid TypeId { get; set; }
}
public class DeletePmsTypeCommandHandler(IPMSTypesService service) : IRequestHandler<DeletePmsTypeCommand, IResponse>
{
    private readonly IPMSTypesService _service = service;

    public async Task<IResponse> Handle(DeletePmsTypeCommand request, CancellationToken cancellationToken)
    {
        var result = await _service.DeleteAsync(request.TypeId,cancellationToken);
        if (result != 0)
        {
            return Response<int>.Success(data: result, message: "Pms type Information Deleted!");
        }
        return Response<int>.Fail(message: "Type Couldn't be Found");
    }
}

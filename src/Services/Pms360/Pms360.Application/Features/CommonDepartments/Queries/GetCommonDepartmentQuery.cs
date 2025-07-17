
namespace Pms360.Application.Features.CommonDepartments.Queries;
public class GetCommonDepartmentQuery : IRequest<IResponse>
{
}
public class GetCommonDepartmentQueryHandler(ICommonDepartmentService service) : IRequestHandler<GetCommonDepartmentQuery, IResponse>
{
    private readonly ICommonDepartmentService _service = service;

    public async Task<IResponse> Handle(GetCommonDepartmentQuery request, CancellationToken cancellationToken)
    {
        var response = await _service.GetAllAsync(cancellationToken);
        return response.Count > 0
           ? Response<List<CommonDepartment>>.Success(data: response)
           : Response<List<CommonDepartment>>.Fail(message: "There is no Department Exists");
    }
}

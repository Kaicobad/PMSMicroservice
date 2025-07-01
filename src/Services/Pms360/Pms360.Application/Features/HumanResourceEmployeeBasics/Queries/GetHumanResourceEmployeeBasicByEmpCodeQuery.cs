namespace Pms360.Application.Features.HumanResourceEmployeeBasics.Queries;
public class GetHumanResourceEmployeeBasicByEmpCodeQuery : IRequest<IResponse<HumanResourceEmployeeBasic>>,IValidatable
{
    public string EmpCode { get; set; }
}
public class GetHumanResourceEmployeeBasicByEmpCodeQueryHandler(IHumanResourceEmployeeBasicService service) : IRequestHandler<GetHumanResourceEmployeeBasicByEmpCodeQuery, IResponse<HumanResourceEmployeeBasic>>
{
    private readonly IHumanResourceEmployeeBasicService _service = service;

    public async Task<IResponse<HumanResourceEmployeeBasic>> Handle(GetHumanResourceEmployeeBasicByEmpCodeQuery request, CancellationToken cancellationToken)
    {
        var response = await _service.GetByCodeAsync(request.EmpCode, cancellationToken);
        if (response != null)
        {
            return Response<HumanResourceEmployeeBasic>.Success(data: response.Adapt<HumanResourceEmployeeBasic>());
        }
        else
        {
            return Response<HumanResourceEmployeeBasic>.Fail("Employee Basic Information Does Not Exists !");
        }
    }
}

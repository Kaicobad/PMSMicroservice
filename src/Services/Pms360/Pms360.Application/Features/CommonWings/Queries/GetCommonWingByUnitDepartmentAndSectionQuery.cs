
namespace Pms360.Application.Features.CommonWings.Queries;
public class GetCommonWingByUnitDepartmentAndSectionQuery : IRequest<IResponse<List<CommonWing>>>
{
    public int UnitId { get; set; }
    public int DepartmentId { get; set; }
    public int SectionId { get; set; }
}
public class GetCommonWingByUnitDepartmentAndSectionQueryHandler(ICommonWingService service) : IRequestHandler<GetCommonWingByUnitDepartmentAndSectionQuery, IResponse<List<CommonWing>>>
{
    private readonly ICommonWingService _service = service;

    public async Task<IResponse<List<CommonWing>>> Handle(GetCommonWingByUnitDepartmentAndSectionQuery request, CancellationToken cancellationToken)
    {
        var wings = await _service.GetAllByUnitDeptAndSection(request.UnitId,request.DepartmentId,request.SectionId,cancellationToken);
        if (wings.Count > 0)
        {
           return Response<List<CommonWing>>.Success(wings);
        }
        return Response<List<CommonWing>>.Fail("wings doesn't Exists!");

    }
}

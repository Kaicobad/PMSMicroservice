
namespace Pms360.Application.Features.CommonSections.Queries;
public class GetCommonSectionByUnitIdAndDeptIdQuery : IRequest<IResponse<List<CommonSection>>>
{
    public int UnitId { get; set; }
    public int DepartmentId { get; set; }
}
public class GetCommonSectionByUnitIdAndDeptIdQueryHandler(ICommonSectionService service) : IRequestHandler<GetCommonSectionByUnitIdAndDeptIdQuery, IResponse<List<CommonSection>>>
{
    private readonly ICommonSectionService _service = service;

    public async Task<IResponse<List<CommonSection>>> Handle(GetCommonSectionByUnitIdAndDeptIdQuery request, CancellationToken cancellationToken)
    {
        var sections = await _service.GetByUnitAndDeptAsync(request.UnitId,request.DepartmentId,cancellationToken);
        if (sections.Count > 0)
        {
            return Response<List<CommonSection>>.Success(sections);
        }
        return Response<List<CommonSection>>.Fail("Section Doesnt exists in this department");
    }
}

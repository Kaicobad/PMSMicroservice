namespace Pms360.Application.Features.CommonWings;
public interface ICommonWingService
{
    Task<List<CommonWing>> GetAllByUnitDeptAndSection(int UnitId, int DepartmentId, int SectionId, CancellationToken cancellationToken);
    Task<bool> IsExistsAsync(int WingId, CancellationToken cancellationToken);
}

namespace Pms360.Application.Features.CommonSections;
public interface ICommonSectionService
{
    Task<List<CommonSection>> GetAllAsync(CancellationToken cancellationToken);
    Task<List<CommonSection>> GetByUnitAndDeptAsync(int UnitId, int DeptId, CancellationToken cancellationToken);
    Task<bool> IsExistsAsync(int SectionId, CancellationToken cancellationToken);
}

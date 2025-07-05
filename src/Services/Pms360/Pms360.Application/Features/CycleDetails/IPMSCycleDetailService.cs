using Pms360.Domain.Entities;

namespace Pms360.Application.Features.CycleDetails;
public interface IPMSCycleDetailService
{
    Task<Guid> CreateAsync(PMSCycleDetails pmsCycleDetails, CancellationToken cancellationToken);
    Task<PMSType> UpdateAsync(PMSCycleDetails pmsCycleDetails, CancellationToken cancellationToken);
    Task<int> DeleteAsync(Guid id, CancellationToken cancellationToken);
    Task<PMSType> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    Task<PaginatedList<PMSType>> GetAllWithPagination(int pageNumber, int pageSize, CancellationToken cancellationToken);
    Task<List<PMSCycleDetails>> GetAllNoFilter(CancellationToken cancellationToken);
    Task<bool> IsExistsAsync(Guid id, CancellationToken cancellationToken);
    Task<bool> IsNameExistsAsync(string name, CancellationToken cancellationToken);
}

namespace Pms360.Application.Features.PMSCycles;
public interface IPMSCycleService
{
    Task<Guid> CreateAsync(PMSCycle pmsCycle, CancellationToken cancellationToken);
    Task<PMSCycle> UpdateAsync(PMSCycle pmsCycle, CancellationToken cancellationToken);
    Task<int> DeleteAsync(Guid id, CancellationToken cancellationToken);
    Task<PMSCycle> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    Task<PaginatedList<PMSCycle>> GetByTypeAndDurationAsync(Guid pmsTypeID,Guid pmsDurationTypeId, int pageNumber, int pageSize, CancellationToken cancellationToken);
    Task<PaginatedList<PMSCycle>> GetAllPaginatedList(int pageNumber, int pageSize, CancellationToken cancellation);
    Task<bool> IsExistsAsync(Guid id, CancellationToken cancellationToken);

}

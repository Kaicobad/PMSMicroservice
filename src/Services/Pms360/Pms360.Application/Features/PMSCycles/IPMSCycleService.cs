namespace Pms360.Application.Features.PMSCycles;
public interface IPMSCycleService
{
    Task<Guid> CreateAsync(Pmscycle pmsCycle, CancellationToken cancellationToken);
    Task<Pmscycle> UpdateAsync(Pmscycle pmsCycle, CancellationToken cancellationToken);
    Task<int> DeleteAsync(Guid id, CancellationToken cancellationToken);
    Task<Pmscycle> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    Task<PaginatedList<Pmscycle>> GetByTypeAndDurationAsync(Guid pmsTypeID,Guid pmsDurationTypeId, int pageNumber, int pageSize, CancellationToken cancellationToken);
    Task<PaginatedList<Pmscycle>> GetAllPaginatedList(int pageNumber, int pageSize, CancellationToken cancellation);
    Task<bool> IsExistsAsync(Guid id, CancellationToken cancellationToken);

}

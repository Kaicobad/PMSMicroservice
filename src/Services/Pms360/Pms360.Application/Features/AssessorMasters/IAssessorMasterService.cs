namespace Pms360.Application.Features.AssessorMasters;
public interface IAssessorMasterService
{
    Task<Guid> CreateAsync(AssessorMaster assessorMaster, CancellationToken cancellationToken);
    Task<AssessorMaster> UpdateAsync(AssessorMaster assessorMaster, CancellationToken cancellationToken);
    Task<int> DeleteAsync(Guid id, CancellationToken cancellationToken);
    Task<AssessorMaster> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    Task<AssessorMaster> GetByClientIdAsync(Guid clientId,Guid assessorMasterId, CancellationToken cancellationToken);
    Task<List<AssessorMaster>> GetAll(CancellationToken cancellationToken);
    Task<PaginatedList<AssessorMaster>> GetAllWithPagination(int pageNumber, int pageSize, CancellationToken cancellationToken);
    Task<List<AssessorMaster>> GetAllNoFilter(CancellationToken cancellationToken);
    Task<bool> IsExistsAsync(Guid id, CancellationToken cancellationToken);
}

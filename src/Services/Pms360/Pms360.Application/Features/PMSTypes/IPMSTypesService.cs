namespace Pms360.Application.Features.PMSTypes;
public interface IPMSTypesService
{
    Task<Guid> CreateAsync(Pmstype pmsType, CancellationToken cancellationToken);
    Task<Pmstype> UpdateAsync(Pmstype pmsType, CancellationToken cancellationToken);
    Task<int> DeleteAsync(Guid id, CancellationToken cancellationToken);
    Task<Pmstype> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    Task<List<Pmstype>> GetAll(CancellationToken cancellationToken);
    Task<PaginatedList<Pmstype>> GetAllWithPagination(int pageNumber,int pageSize,CancellationToken cancellationToken);
    Task<List<Pmstype>> GetAllNoFilter(CancellationToken cancellationToken);
    Task<bool> IsExistsAsync(Guid id, CancellationToken cancellationToken);
    Task<bool> IsNameExistsAsync(string name, CancellationToken cancellationToken);
}

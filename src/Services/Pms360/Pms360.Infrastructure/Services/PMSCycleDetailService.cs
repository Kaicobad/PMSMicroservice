
namespace Pms360.Infrastructure.Services;
public class PMSCycleDetailService : IPMSCycleDetailService
{
    public Task<Guid> CreateAsync(PmscycleDetail pmsCycleDetails, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<int> DeleteAsync(Guid id, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<List<PmscycleDetail>> GetAllNoFilter(CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<PaginatedList<Pmstype>> GetAllWithPagination(int pageNumber, int pageSize, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<Pmstype> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<bool> IsExistsAsync(Guid id, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<bool> IsNameExistsAsync(string name, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<Pmstype> UpdateAsync(PmscycleDetail pmsCycleDetails, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}

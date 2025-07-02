
namespace Pms360.Infrastructure.Services;
public class PMSCycleDetailService : IPMSCycleDetailService
{
    public Task<Guid> CreateAsync(PMSCycleDetails pmsCycleDetails, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<int> DeleteAsync(Guid id, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<List<PMSCycleDetails>> GetAllNoFilter(CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<PaginatedList<PMSType>> GetAllWithPagination(int pageNumber, int pageSize, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<PMSType> GetByIdAsync(Guid id, CancellationToken cancellationToken)
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

    public Task<PMSType> UpdateAsync(PMSCycleDetails pmsCycleDetails, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}

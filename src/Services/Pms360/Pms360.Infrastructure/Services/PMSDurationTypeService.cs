namespace Pms360.Infrastructure.Services;
public class PMSDurationTypeService(IApplicationDbContext dbContext) : IPMSDurationTypeService
{
    private readonly IApplicationDbContext _dbContext = dbContext;

    public async Task<Guid> CreateAsync(PMSDurationType pmsDurationType, CancellationToken cancellationToken)
    {
        await _dbContext.PMSDurationTypes.AddAsync(pmsDurationType, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);
        return pmsDurationType.DurationTypeId;
    }

    public Task<int> DeleteAsync(Guid id, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public async Task<List<PMSDurationType>> GetAll(CancellationToken cancellationToken)
    {
        var durationTypes = await _dbContext.PMSDurationTypes.Where(x => x.IsActive == true).ToListAsync();
        if (durationTypes.Any())
        {
            return durationTypes;
        }
        else
        {
            return new List<PMSDurationType>();
        }
    }

    public Task<List<PMSDurationType>> GetAllNoFilter(CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<PMSDurationType> GetByIdAsync(Guid id, CancellationToken cancellationToken)
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

    public Task<PMSDurationType> UpdateAsync(PMSDurationType pmsDurationType, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}

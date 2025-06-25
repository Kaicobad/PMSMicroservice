using Pms360.Domain.Entities;

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

    public async Task<bool> IsExistsAsync(Guid id, CancellationToken cancellationToken)
    {
        return await _dbContext.PMSDurationTypes.AnyAsync(types => types.DurationTypeId == id);
    }

    public async Task<bool> IsNameExistsAsync(string name, CancellationToken cancellationToken)
    {
        return await _dbContext.PMSDurationTypes.AnyAsync(types => types.Name == name);
    }

    public async Task<PMSDurationType> UpdateAsync(PMSDurationType pmsDurationType, CancellationToken cancellationToken)
    {

        if (await IsExistsAsync(pmsDurationType.DurationTypeId, cancellationToken))
        {
            _dbContext.PMSDurationTypes.Update(pmsDurationType);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return pmsDurationType;
        }
        return null;
    }
}

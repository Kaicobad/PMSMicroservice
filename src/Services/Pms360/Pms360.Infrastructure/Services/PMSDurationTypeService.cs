using Pms360.Domain.Entities;

namespace Pms360.Infrastructure.Services;
public class PMSDurationTypeService(IApplicationDbContext dbContext) : IPMSDurationTypeService
{
    private readonly IApplicationDbContext _dbContext = dbContext;

    public async Task<Guid> CreateAsync(PmsdurationType pmsDurationType, CancellationToken cancellationToken)
    {
        await _dbContext.PmsdurationTypes.AddAsync(pmsDurationType, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);
        return pmsDurationType.DurationTypeId;
    }

    public Task<int> DeleteAsync(Guid id, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public async Task<List<PmsdurationType>> GetAll(CancellationToken cancellationToken)
    {
        var durationTypes = await _dbContext.PmsdurationTypes.Where(x => x.IsActive == true).ToListAsync();
        if (durationTypes.Any())
        {
            return durationTypes;
        }
        else
        {
            return new List<PmsdurationType>();
        }
    }

    public Task<List<PmsdurationType>> GetAllNoFilter(CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<PmsdurationType> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> IsExistsAsync(Guid id, CancellationToken cancellationToken)
    {
        return await _dbContext.PmsdurationTypes.AnyAsync(types => types.DurationTypeId == id);
    }

    public async Task<bool> IsNameExistsAsync(string name, CancellationToken cancellationToken)
    {
        return await _dbContext.PmsdurationTypes.AnyAsync(types => types.Name == name);
    }

    public async Task<PmsdurationType> UpdateAsync(PmsdurationType pmsDurationType, CancellationToken cancellationToken)
    {

        if (await IsExistsAsync(pmsDurationType.DurationTypeId, cancellationToken))
        {
            _dbContext.PmsdurationTypes.Update(pmsDurationType);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return pmsDurationType;
        }
        return null;
    }
}

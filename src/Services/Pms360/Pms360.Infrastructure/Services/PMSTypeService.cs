
using System.Threading;

namespace Pms360.Infrastructure.Services;
public class PMSTypeService(IApplicationDbContext dbContext) : IPMSTypesService
{
    private readonly IApplicationDbContext _dbContext = dbContext;

    public async Task<Guid> CreateAsync(PMSType pmsType, CancellationToken cancellationToken)
    {
        await _dbContext.PMSTypes.AddAsync(pmsType);
        await _dbContext.SaveChangesAsync(cancellationToken);
        return pmsType.TypeId;
    }

    public async Task<int> DeleteAsync(Guid id, CancellationToken cancellationToken)
    {
        var type = await _dbContext.PMSTypes.FirstOrDefaultAsync(pmsTypes => pmsTypes.TypeId == id);
        if (type is not null)
        {
            type.IsActive = false;
            _dbContext.PMSTypes.Update(type);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return 1;
        }
        return 0;
    }

    public async Task<List<PMSType>> GetAll(CancellationToken cancellationToken)
    {
        var types = await _dbContext.PMSTypes.ToListAsync(cancellationToken);
        if (types.Any())
        {
            return types;
        }
        else
        {
            return new List<PMSType>();
        }
    }

    public async Task<PMSType> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var type = await _dbContext.PMSTypes.FirstOrDefaultAsync(type => type.TypeId == id);
        return type;
    }

    public async Task<bool> IsExistsAsync(Guid id, CancellationToken cancellationToken)
    {
        return await _dbContext.PMSTypes.AnyAsync(types => types.TypeId == id);
    }

    public async Task<PMSType> UpdateAsync(PMSType pmsType, CancellationToken cancellationToken)
    {
        if (await IsExistsAsync(pmsType.TypeId, cancellationToken))
        {
            _dbContext.PMSTypes.Update(pmsType);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return pmsType;
        }
        return null;
    }
}

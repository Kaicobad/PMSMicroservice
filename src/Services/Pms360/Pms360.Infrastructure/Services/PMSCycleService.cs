namespace Pms360.Infrastructure.Services;
public class PMSCycleService(IApplicationDbContext dbContext, IMapper mapper) : IPMSCycleService
{
    private readonly IApplicationDbContext _dbContext = dbContext;
    private readonly IMapper _mapper = mapper;

    public async Task<Guid> CreateAsync(Pmscycle pmsCycle, CancellationToken cancellationToken)
    {
        await _dbContext.Pmscycles.AddAsync(pmsCycle);
        await _dbContext.SaveChangesAsync(cancellationToken);
        return pmsCycle.CycleId;
    }

    public Task<int> DeleteAsync(Guid id, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public async Task<PaginatedList<Pmscycle>> GetAllPaginatedList(int pageNumber, int pageSize, CancellationToken cancellation)
    {
        var query = _dbContext.Pmscycles
                 .OrderBy(x=> x.CycleId)
                 .ProjectToType<Pmscycle>(_mapper.Config);
        return await query.PaginatedListAsync(pageNumber, pageSize);
    }

    public Task<Pmscycle> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public async Task<PaginatedList<Pmscycle>> GetByTypeAndDurationAsync(Guid pmsTypeId, Guid pmsDurationTypeId,int pageNumber,int pageSize, CancellationToken cancellationToken)
    {
        var query = _dbContext.Pmscycles
            .Where(x => x.PmstypeId == pmsTypeId && x.PmsdurationTypeId == pmsDurationTypeId)
            .ProjectToType<Pmscycle>(_mapper.Config);

        return await query.PaginatedListAsync(pageNumber, pageSize);
    }

    public async Task<bool> IsExistsAsync(Guid id, CancellationToken cancellationToken)
    {
        return await _dbContext.Pmscycles.AnyAsync(types => types.CycleId == id);
    }

    public async Task<Pmscycle> UpdateAsync(Pmscycle pmsCycle, CancellationToken cancellationToken)
    {
        if (await IsExistsAsync(pmsCycle.CycleId, cancellationToken))
        {
            _dbContext.Pmscycles.Update(pmsCycle);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return pmsCycle;
        }
        return null;
    }
}

namespace Pms360.Infrastructure.Services;
public class PMSCycleService(IApplicationDbContext dbContext, IMapper mapper) : IPMSCycleService
{
    private readonly IApplicationDbContext _dbContext = dbContext;
    private readonly IMapper _mapper = mapper;

    public async Task<Guid> CreateAsync(PMSCycle pmsCycle, CancellationToken cancellationToken)
    {
        await _dbContext.PMSCycles.AddAsync(pmsCycle);
        await _dbContext.SaveChangesAsync(cancellationToken);
        return pmsCycle.CycleId;
    }

    public Task<int> DeleteAsync(Guid id, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public async Task<PaginatedList<PMSCycle>> GetAllPaginatedList(int pageNumber, int pageSize, CancellationToken cancellation)
    {
        var query = _dbContext.PMSCycles
                 .OrderBy(x=> x.CycleId)
                 .ProjectToType<PMSCycle>(_mapper.Config);
        return await query.PaginatedListAsync(pageNumber, pageSize);
    }

    public Task<PMSCycle> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public async Task<PaginatedList<PMSCycle>> GetByTypeAndDurationAsync(Guid pmsTypeId, Guid pmsDurationTypeId,int pageNumber,int pageSize, CancellationToken cancellationToken)
    {
        var query = _dbContext.PMSCycles
            .Where(x => x.PMSTypeId == pmsTypeId && x.PMSDurationTypeId == pmsDurationTypeId)
            .ProjectToType<PMSCycle>(_mapper.Config);

        return await query.PaginatedListAsync(pageNumber, pageSize);
    }

    public async Task<bool> IsExistsAsync(Guid id, CancellationToken cancellationToken)
    {
        return await _dbContext.PMSTypes.AnyAsync(types => types.TypeId == id);
    }

    public async Task<PMSCycle> UpdateAsync(PMSCycle pmsCycle, CancellationToken cancellationToken)
    {
        if (await IsExistsAsync(pmsCycle.CycleId, cancellationToken))
        {
            _dbContext.PMSCycles.Update(pmsCycle);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return pmsCycle;
        }
        return null;
    }
}

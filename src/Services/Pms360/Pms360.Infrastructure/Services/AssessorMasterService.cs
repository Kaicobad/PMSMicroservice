using Pms360.Domain.Entities;

namespace Pms360.Infrastructure.Services;
public class AssessorMasterService(IApplicationDbContext dbContext, IMapper mapper) : IAssessorMasterService
{
    private readonly IApplicationDbContext _dbContext = dbContext;
    private readonly IMapper _mapper = mapper;

    public async Task<Guid> CreateAsync(AssessorMaster assessorMaster, CancellationToken cancellationToken)
    {
        await _dbContext.AssessorMasters.AddAsync(assessorMaster);
        await _dbContext.SaveChangesAsync(cancellationToken);
        return assessorMaster.AssessorMasterId;
    }

    public async Task<int> DeleteAsync(Guid id, CancellationToken cancellationToken)
    {
        var assessorMaster = await _dbContext.AssessorMasters.FirstOrDefaultAsync(x => x.AssessorMasterId == id);
        if (assessorMaster is not null)
        {
            assessorMaster.IsActive = false;
            _dbContext.AssessorMasters.Update(assessorMaster);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return 1;
        }
        return 0;
    }

    public async Task<AssessorMaster> UpdateAsync(AssessorMaster assessorMaster, CancellationToken cancellationToken)
    {
        if (await IsExistsAsync(assessorMaster.AssessorMasterId, cancellationToken))
        {
            _dbContext.AssessorMasters.Update(assessorMaster);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return assessorMaster;
        }
        return null;
    }

    public async Task<List<AssessorMaster>> GetAll(CancellationToken cancellationToken)
    {
        var assessorMaster = await _dbContext.AssessorMasters.Where(x => x.IsActive == true).ToListAsync(cancellationToken);
        Guard.Against.NotFound("AssessorMasters", assessorMaster);
        return assessorMaster;
    }

    public async Task<List<AssessorMaster>> GetAllNoFilter(CancellationToken cancellationToken)
    {
        var assessorMaster = await _dbContext.AssessorMasters.ToListAsync(cancellationToken);
        Guard.Against.NotFound("AssessorMasters", assessorMaster);
        return assessorMaster;
    }

    public async Task<PaginatedList<AssessorMaster>> GetAllWithPagination(int pageNumber, int pageSize, CancellationToken cancellationToken)
    {
        var query = _dbContext.AssessorMasters
         .OrderBy(x => x.AssessorMasterId)
         .ProjectToType<AssessorMaster>(_mapper.Config);

        return await query.PaginatedListAsync(pageNumber, pageSize);
    }

    public async Task<AssessorMaster> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var type = await _dbContext.AssessorMasters.FirstOrDefaultAsync(x => x.AssessorMasterId == id);
        return type;
    }

    public async Task<bool> IsExistsAsync(Guid id, CancellationToken cancellationToken)
    {
        return await _dbContext.AssessorMasters.AnyAsync(x => x.AssessorMasterId == id);
    }

    public async Task<AssessorMaster> GetByClientIdAsync(Guid clientId, Guid assessorMasterId, CancellationToken cancellationToken)
    {
        var assessorMaster = await _dbContext.AssessorMasters
            .Where(x=>x.ClientId == clientId && 
                                x.AssessorMasterId == assessorMasterId)
                                .FirstOrDefaultAsync(cancellationToken);
        Guard.Against.NotFound("AssessorMaster", assessorMaster);
        return assessorMaster;
    }
}

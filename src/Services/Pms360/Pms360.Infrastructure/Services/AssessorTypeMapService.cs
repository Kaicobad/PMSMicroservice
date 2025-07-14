
namespace Pms360.Infrastructure.Services;
public class AssessorTypeMapService(IApplicationDbContext dbContext) : IAssessorTypeMapService
{
    private readonly IApplicationDbContext _dbContext = dbContext;

    public async Task<Guid> CreateAsync(AssessorTypeMap assessorTypeMap, CancellationToken cancellationToken)
    {
        await _dbContext.AssessorTypeMaps.AddAsync(assessorTypeMap);
        await _dbContext.SaveChangesAsync(cancellationToken);
        return assessorTypeMap.AssessorTypeMapId;
    }

    public async Task<List<AssessorTypeMap>> GetAllAsync(CancellationToken cancellationToken)
    {
        var assessorTypeMap = await _dbContext.AssessorTypeMaps.Where(x => x.IsActive == true).ToListAsync(cancellationToken);
        Guard.Against.NotFound("AssessorTypeMap", assessorTypeMap);
        return assessorTypeMap;
    }

    public async Task<bool> IsExistsAsync(Guid id, CancellationToken cancellationToken)
    {
        return await _dbContext.AssessorTypeMaps.AnyAsync(x => x.AssessorTypeMapId == id);
    }
}

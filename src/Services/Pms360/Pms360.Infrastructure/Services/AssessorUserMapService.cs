
using Microsoft.EntityFrameworkCore;
using Pms360.Domain.Entities;

namespace Pms360.Infrastructure.Services;
public class AssessorUserMapService(IApplicationDbContext dbContext) : IAssessorUserMapService
{
    private readonly IApplicationDbContext _dbContext = dbContext;

    public async Task<Guid> CreateAsync(AssessorUserMap assessorUserMap, CancellationToken cancellationToken)
    {
        await _dbContext.AssessorUserMaps.AddAsync(assessorUserMap);
        await _dbContext.SaveChangesAsync(cancellationToken);
        return assessorUserMap.AssessorTypeMapId;
    }

    public async Task<List<AssessorUserMap>> GetAllAsync(CancellationToken cancellationToken)
    {
        var assessorUserMap = await _dbContext.AssessorUserMaps.Where(x => x.IsActive == true).ToListAsync(cancellationToken);
        Guard.Against.NotFound("AssessorUserMap", assessorUserMap);
        return assessorUserMap;
    }

    public async Task<bool> IsExistsAsync(Guid id, CancellationToken cancellationToken)
    {
        return await _dbContext.AssessorUserMaps.AnyAsync(x => x.AssessorUserMapId == id);
    }
}

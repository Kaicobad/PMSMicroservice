
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

    public async Task<bool> IsExistsAsync(Guid id, CancellationToken cancellationToken)
    {
        return await _dbContext.AssessorUserMaps.AnyAsync(x => x.AssessorUserMapId == id);
    }
}

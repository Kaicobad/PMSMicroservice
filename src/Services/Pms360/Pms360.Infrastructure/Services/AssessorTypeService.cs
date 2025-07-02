namespace Pms360.Infrastructure.Services;
public class AssessorTypeService(IApplicationDbContext dbContext, IMapper mapper) : IAssessorTypeService
{
    private readonly IApplicationDbContext _dbContext = dbContext;
    private readonly IMapper _mapper = mapper;

    public async Task<Guid> CreateAsync(AssessorType assessorType, CancellationToken cancellationToken)
    {
        await _dbContext.AssessorTypes.AddAsync(assessorType);
        await _dbContext.SaveChangesAsync(cancellationToken);
        return assessorType.TypeId;
    }

    public async Task<int> DeleteAsync(Guid id, CancellationToken cancellationToken)
    {
        var type = await _dbContext.AssessorTypes.FirstOrDefaultAsync(pmsTypes => pmsTypes.TypeId == id);
        if (type is not null)
        {
            type.IsActive = false;
            _dbContext.AssessorTypes.Update(type);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return 1;
        }
        return 0;
    }

    public async Task<List<AssessorType>> GetAll(CancellationToken cancellationToken)
    {
        var types = await _dbContext.AssessorTypes.Where(x => x.IsActive == true).ToListAsync(cancellationToken);
        Guard.Against.NotFound("AssessorTypes", types);
        return types;
    }

    public async Task<List<AssessorType>> GetAllNoFilter(CancellationToken cancellationToken)
    {
        var types = await _dbContext.AssessorTypes.ToListAsync(cancellationToken);
        Guard.Against.NotFound("AssessorTypes", types);
        return types;
    }

    public async Task<AssessorType> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var type = await _dbContext.AssessorTypes.FirstOrDefaultAsync(type => type.TypeId == id);
        return type;
    }

    public async Task<bool> IsExistsAsync(Guid id, CancellationToken cancellationToken)
    {
        return await _dbContext.AssessorTypes.AnyAsync(types => types.TypeId == id);
    }

    public async Task<bool> IsNameExistsAsync(string name, CancellationToken cancellationToken)
    {
        return await _dbContext.AssessorTypes.AnyAsync(types => types.TypeName == name);
    }

    public async Task<AssessorType> UpdateAsync(AssessorType assessorType, CancellationToken cancellationToken)
    {
        if (await IsExistsAsync(assessorType.TypeId, cancellationToken))
        {
            _dbContext.AssessorTypes.Update(assessorType);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return assessorType;
        }
        return null;
    }
}

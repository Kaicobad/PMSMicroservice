using Pms360.Application.Models.Requests;

namespace Pms360.Infrastructure.Services;
public class PMSTypeService(IApplicationDbContext dbContext, IMapper mapper) : IPMSTypesService
{
    private readonly IApplicationDbContext _dbContext = dbContext;
    private readonly IMapper _mapper = mapper;

    public async Task<Guid> CreateAsync(Pmstype pmsType, CancellationToken cancellationToken)
    {
        await _dbContext.Pmstypes.AddAsync(pmsType);
        await _dbContext.SaveChangesAsync(cancellationToken);
        return pmsType.TypeId;
    }

    public async Task<int> DeleteAsync(Guid id, CancellationToken cancellationToken)
    {
        var type = await _dbContext.Pmstypes.FirstOrDefaultAsync(pmsTypes => pmsTypes.TypeId == id);
        if (type is not null)
        {
            type.IsActive = false;
            _dbContext.Pmstypes.Update(type);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return 1;
        }
        return 0;
    }

    public async Task<List<Pmstype>> GetAll(CancellationToken cancellationToken)
    {
        var types = await _dbContext.Pmstypes.Where(x => x.IsActive == true).ToListAsync(cancellationToken);
        Guard.Against.NotFound("PMSTypes", types);
        return types;
        #region old get code
        //if (types.Any())
        //{
        //    return types;
        //}
        //else
        //{
        //    return new List<PMSType>();
        //}
        #endregion
    }

    public async Task<List<Pmstype>> GetAllNoFilter(CancellationToken cancellationToken)
    {
        var types = await _dbContext.Pmstypes.ToListAsync(cancellationToken);
        Guard.Against.NotFound("PMSTypes", types);
        return types;
    }

    public async Task<PaginatedList<Pmstype>> GetAllWithPagination(int pageNumber,int pageSize,CancellationToken cancellationToken)
    {
        var query = _dbContext.Pmstypes
        .OrderBy(x => x.Name)
        .ProjectToType<Pmstype>(_mapper.Config);

         return await query.PaginatedListAsync(pageNumber, pageSize);
    }

    public async Task<Pmstype> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var type = await _dbContext.Pmstypes.FirstOrDefaultAsync(type => type.TypeId == id);
        return type;
    }

    public async Task<bool> IsExistsAsync(Guid id, CancellationToken cancellationToken)
    {
        return await _dbContext.Pmstypes.AnyAsync(types => types.TypeId == id);
    }

    public async Task<bool> IsNameExistsAsync(string name, CancellationToken cancellationToken)
    {
        return await _dbContext.Pmstypes.AnyAsync(types => types.Name == name);
    }

    public async Task<Pmstype> UpdateAsync(Pmstype pmsType, CancellationToken cancellationToken)
    {
        if (await IsExistsAsync(pmsType.TypeId, cancellationToken))
        {
            _dbContext.Pmstypes.Update(pmsType);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return pmsType;
        }
        return null;
    }
}

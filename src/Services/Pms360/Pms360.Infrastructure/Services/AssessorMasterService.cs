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
       .Where(x => x.ClientId == clientId && x.AssessorMasterId == assessorMasterId)
       .FirstOrDefaultAsync(cancellationToken);
        Guard.Against.NotFound("AssessorMaster", assessorMaster);
        return assessorMaster;
    }

    public async Task<PaginatedList<AssessorMaster>> GetByAssessorMaserIdWithPagination(Guid masterId,int pageNumber, int pageSize, CancellationToken cancellationToken)
    {
        var query = _dbContext.AssessorMasters.Where(x => x.AssessorMasterId == masterId)
         .OrderBy(x => x.AssessorMasterId)
         .ProjectToType<AssessorMaster>(_mapper.Config);

        return await query.PaginatedListAsync(pageNumber, pageSize);
    }
    public async Task<List<AssessorMasterDTO>> GetByAssessorMaserId(Guid masterId, CancellationToken cancellationToken)
    {
        #region Previious
        //var assessorMaster = await _dbContext.AssessorMasters
        //    .AsNoTracking()
        //    .Where(x=>x.AssessorMasterId == masterId)
        //    .Include(x => x.AssessorTypeMaps)
        //    .Include(x => x.AssessorUserMaps)
        //    .ToListAsync(cancellationToken);
        //Guard.Against.NotFound("AssessorMaster", assessorMaster);
        //return assessorMaster;
        #endregion

        var result = await _dbContext.AssessorMasters
      .Where(x => x.AssessorMasterId == masterId)
      .Select(x => new AssessorMasterDTO
      {
          AssessorMasterId = x.AssessorMasterId,
          ClientId = x.ClientId,
          IsForUser = x.IsForUser,
          IsForUnit = x.IsForUnit,
          IsForDepartment = x.IsForDepartment,
          IsForSection = x.IsForSection,
          IsForWing = x.IsForWing,
          IsForTeam = x.IsForTeam,

          AssessorTypeMaps = x.AssessorTypeMaps.Select(at => new AssessorTypeMapDTO
          {
              AssessorTypeMapId = at.AssessorTypeMapId,
              AssessorMasterId = at.AssessorMasterId,
              AssessorTypeId = at.AssessorTypeId,

              AssessorType = new AssessorTypeDTO
              {
                  TypeId = at.AssessorType.TypeId,
                  TypeName = at.AssessorType.TypeName
              },

              AssessorUserMaps = at.AssessorUserMaps.Select(um => new AssessorUserMapDTO
              {
                  AssessorUserMapId = um.AssessorUserMapId,
                  AssessorMasterId = um.AssessorMasterId,
                  UserId = um.UserId
              }).ToList()

          }).ToList(),

          AssessorUserMaps = x.AssessorUserMaps.Select(um => new AssessorUserMapDTO
          {
              AssessorUserMapId = um.AssessorUserMapId,
              AssessorMasterId = um.AssessorMasterId,
              UserId = um.UserId
          }).ToList()
      })
      .ToListAsync(cancellationToken);



        return result;
    }

}

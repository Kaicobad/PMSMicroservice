namespace Pms360.Infrastructure.Services;
public class AssessorMasterService(IApplicationDbContext dbContext,AuthDbContext authDbContext, IMapper mapper) : IAssessorMasterService
{
    private readonly IApplicationDbContext _dbContext = dbContext;
    private readonly AuthDbContext _authDbContext = authDbContext;
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

        #region Later Previous
        //var userData = await  _usersService.GetAll(cancellationToken);

        // var result = await _dbContext.AssessorMasters
        //.Where(x => x.AssessorMasterId == masterId)
        //.Select(x => new AssessorMasterDTO
        //{
        //    AssessorMasterId = x.AssessorMasterId,
        //    ClientId = x.ClientId,
        //    IsForUser = x.IsForUser,
        //    IsForUnit = x.IsForUnit,
        //    IsForDepartment = x.IsForDepartment,
        //    IsForSection = x.IsForSection,
        //    IsForWing = x.IsForWing,
        //    IsForTeam = x.IsForTeam,

        //    AssessorTypeMaps = x.AssessorTypeMaps.Select(at => new AssessorTypeMapDTO
        //    {
        //        AssessorTypeMapId = at.AssessorTypeMapId,
        //        AssessorMasterId = at.AssessorMasterId,
        //        AssessorTypeId = at.AssessorTypeId,

        //        AssessorType = new AssessorTypeDTO
        //        {
        //            TypeId = at.AssessorType.TypeId,
        //            TypeName = at.AssessorType.TypeName,
        //            Description = at.AssessorType.Description
        //        },

        //        AssessorUserMaps = at.AssessorUserMaps.Select(um => new AssessorUserMapDTO
        //        {
        //            AssessorUserMapId = um.AssessorUserMapId,
        //            AssessorMasterId = um.AssessorMasterId,
        //            UserId = um.UserId
        //        }).ToList()

        //    }).ToList(),

        //    //AssessorUserMaps = x.AssessorUserMaps.Select(um => new AssessorUserMapDTO
        //    //{
        //    //    AssessorUserMapId = um.AssessorUserMapId,
        //    //    AssessorMasterId = um.AssessorMasterId,
        //    //    UserId = um.UserId
        //    //}).ToList()
        //})
        //.ToListAsync(cancellationToken);
        #endregion

        // STEP 1: Query Assessor data from _dbContext
        var assessorData = await (
             from am in _dbContext.AssessorMasters
             where am.AssessorMasterId == masterId
             select new AssessorMasterDTO
             {
                 AssessorMasterId = am.AssessorMasterId,
                 ClientId = am.ClientId,
                 IsForUser = am.IsForUser,
                 IsForUnit = am.IsForUnit,
                 IsForDepartment = am.IsForDepartment,
                 IsForSection = am.IsForSection,
                 IsForWing = am.IsForWing,
                 IsForTeam = am.IsForTeam,

                 AssessorTypeMaps = (
                     from at in am.AssessorTypeMaps
                     select new AssessorTypeMapDTO
                     {
                         AssessorTypeMapId = at.AssessorTypeMapId,
                         AssessorMasterId = at.AssessorMasterId,
                         AssessorTypeId = at.AssessorTypeId,

                         AssessorType = new AssessorTypeDTO
                         {
                             TypeId = at.AssessorType.TypeId,
                             TypeName = at.AssessorType.TypeName,
                             Description = at.AssessorType.Description
                         },

                         AssessorUserMaps = (
                             from um in at.AssessorUserMaps
                             select new AssessorUserMapDTO
                             {
                                 AssessorUserMapId = um.AssessorUserMapId,
                                 AssessorMasterId = um.AssessorMasterId,
                                 UserId = um.UserId,
                                 Name = null,
                                 EmpCode = null
                             }
                         ).ToList()
                     }
                 ).ToList()
             }
         ).ToListAsync(cancellationToken);

        // STEP 2: Extract all UserIds from AssessorUserMaps
        var userIds = assessorData
            .SelectMany(am => am.AssessorTypeMaps)
            .SelectMany(tm => tm.AssessorUserMaps)
            .Select(um => um.UserId.ToString())
            .Distinct()
            .ToList();

        // STEP 3: Fetch users from _authDbContext based on UserIds
        var userList = await _authDbContext.AspNetUsers
            .Where(u => userIds.Contains(u.Id))
            .Select(u => new { u.Id, u.Name, u.EmpCode })
            .ToListAsync(cancellationToken);

        // Convert to Dictionary for fast lookup
        var userDict = userList.ToDictionary(u => u.Id, u => (u.Name, u.EmpCode));

        // STEP 4: Map Name and EmpCode back into DTOs
        foreach (var assessor in assessorData)
        {
            foreach (var typeMap in assessor.AssessorTypeMaps)
            {
                foreach (var userMap in typeMap.AssessorUserMaps)
                {
                    if (userDict.TryGetValue(userMap.UserId.ToString(), out var userInfo))
                    {
                        userMap.Name = userInfo.Name;
                        userMap.EmpCode = userInfo.EmpCode;
                    }
                }
            }
        }

        // Final result
        return assessorData;
    }

}

namespace Pms360.Infrastructure.AuthApiServices;
public class AspNetUsersService(AuthDbContext dbContext) : IAspNetUsersService
{
    private readonly AuthDbContext _dbContext = dbContext;

    public async Task<List<AspNetUser>> GetAll(CancellationToken cancellationToken)
    {
        var response = await _dbContext.AspNetUsers.ToListAsync(cancellationToken);
        Guard.Against.NotFound("AspNetUsers", response);
        return response;
    }

    public async Task<AspNetUser> GetByCodeAsync(string code, CancellationToken cancellationToken)
    {
        var response = await _dbContext.AspNetUsers.Where(x => x.EmpCode == code).FirstOrDefaultAsync(cancellationToken);
        Guard.Against.NotFound("AspNetUsers", response);
        return response;
    }

    public async Task<AspNetUser> GetByUserIdAsync(string id, CancellationToken cancellationToken)
    {
        var response = await _dbContext.AspNetUsers.Where(x => x.Id == id).FirstOrDefaultAsync(cancellationToken);
        Guard.Against.NotFound("AspNetUsers", response);
        return response;
    }

    public async Task<bool> IsExistsAsync(string code, CancellationToken cancellationToken)
    {
        return await _dbContext.AspNetUsers.AnyAsync(x => x.EmpCode == code);
    }
}

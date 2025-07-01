namespace Pms360.Infrastructure.CoreERPServices;
public class CommonCompanyService(CoreERPDbContext dbContext) : ICommonCompanyService
{
    private readonly CoreERPDbContext _dbContext = dbContext;

    public async Task<List<CommonCompany>> GetAllAsync(CancellationToken cancellationToken)
    {
        var companies = await _dbContext.CommonCompanies.Where(x=> x.IsActive == true).ToListAsync(cancellationToken);
        Guard.Against.NotFound("Companies",companies);
        return companies;
    }
    public async Task<CommonCompany> GetByIdAsync(int CompanyId, CancellationToken cancellationToken)
    {
        var company = await _dbContext.CommonCompanies.Where(x => x.CompanyId == CompanyId && x.IsActive == true).FirstOrDefaultAsync(cancellationToken);
        Guard.Against.NotFound("Company", company);
        return company;
    }

    public async Task<bool> IsExistsAsync(int CompanyId, CancellationToken cancellationToken)
    {
        return await _dbContext.CommonCompanies.AnyAsync(comp => comp.CompanyId == CompanyId);
    }
}

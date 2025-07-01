namespace Pms360.Application.Features.CommonCompanies;
public interface ICommonCompanyService
{
    Task<List<CommonCompany>> GetAllAsync(CancellationToken cancellationToken);
    Task<CommonCompany> GetByIdAsync(int CompanyId, CancellationToken cancellationToken);
    Task<bool> IsExistsAsync(int CompanyId, CancellationToken cancellationToken);
}

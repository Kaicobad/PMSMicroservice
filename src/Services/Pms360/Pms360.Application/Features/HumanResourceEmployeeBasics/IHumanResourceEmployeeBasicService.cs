namespace Pms360.Application.Features.HumanResourceEmployeeBasics;
public interface IHumanResourceEmployeeBasicService
{
    Task<HumanResourceEmployeeBasic> GetByCodeAsync(string EmpCode, CancellationToken cancellationToken);
    //Task<List<HumanResourceEmployeeBasic>> GetByCompanyAsync(int CompanyId, CancellationToken cancellationToken);
    Task<List<HumanResourceEmployeeBasic>> GetByUnitAsync(int UnitId, CancellationToken cancellationToken);
    Task<List<HumanResourceEmployeeBasic>> GetByDepartmentAsync(int DepartmentId, CancellationToken cancellationToken);
    Task<List<HumanResourceEmployeeBasic>> GetBySectionAsync(int SectionId, CancellationToken cancellationToken);
    Task<List<HumanResourceEmployeeBasic>> GetByWingAsync(int WingId, CancellationToken cancellationToken);
    Task<List<HumanResourceEmployeeBasic>> GetByTeamAsync(int TeamId, CancellationToken cancellationToken);

    Task<List<HumanResourceEmployeeBasic>> GetByAllFilterAsync(int CompanyId,int UnitId, int DepartmentId, int DesignationId, int SectionId, int WingId, int TeamId,  CancellationToken cancellationToken);
    Task<bool> IsExistsByEmpCodeAsync(string EmpCode, CancellationToken cancellationToken);


}

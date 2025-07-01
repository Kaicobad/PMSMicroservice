namespace Pms360.Application.Features.CommonDepartments;
public interface ICommonDepartmentService
{
    Task<CommonDepartment> GetByIdAsync(int DepartmentId, CancellationToken cancellationToken);
    Task<List<CommonDepartment>> GetAllAsync(CancellationToken cancellationToken);
}

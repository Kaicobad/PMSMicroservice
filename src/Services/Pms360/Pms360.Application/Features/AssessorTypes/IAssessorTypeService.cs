namespace Pms360.Application.Features.AssessorTypes;
public interface IAssessorTypeService
{
    Task<Guid> CreateAsync(AssessorType assessorType, CancellationToken cancellationToken);
    Task<AssessorType> UpdateAsync(AssessorType pmsType, CancellationToken cancellationToken);
    Task<int> DeleteAsync(Guid id, CancellationToken cancellationToken);
    Task<AssessorType> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    Task<List<AssessorType>> GetAll(CancellationToken cancellationToken);
    Task<List<AssessorType>> GetAllNoFilter(CancellationToken cancellationToken);
    Task<bool> IsExistsAsync(Guid id, CancellationToken cancellationToken);
    Task<bool> IsNameExistsAsync(string name, CancellationToken cancellationToken);
}

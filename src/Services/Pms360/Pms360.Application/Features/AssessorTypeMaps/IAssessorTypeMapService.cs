namespace Pms360.Application.Features.AssessorTypeMaps;
public interface IAssessorTypeMapService
{
    Task<Guid> CreateAsync(AssessorTypeMap assessorTypeMap, CancellationToken cancellationToken);
    Task<bool> IsExistsAsync(Guid id, CancellationToken cancellationToken);
    Task<List<AssessorTypeMap>> GetAllAsync(CancellationToken cancellationToken);
}

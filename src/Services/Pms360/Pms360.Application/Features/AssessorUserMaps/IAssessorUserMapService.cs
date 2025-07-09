namespace Pms360.Application.Features.AssessorUserMaps;
public interface IAssessorUserMapService
{
    Task<Guid> CreateAsync(AssessorUserMap assessorUserMap, CancellationToken cancellationToken);
    Task<bool> IsExistsAsync(Guid id, CancellationToken cancellationToken);
}

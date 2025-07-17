namespace Pms360.Application.Features.AspNetUsers;
public interface IAspNetUsersService
{
    Task<List<AspNetUser>> GetAll(CancellationToken cancellationToken);
    Task<AspNetUser> GetByCodeAsync(string code, CancellationToken cancellationToken);
    Task<AspNetUser> GetByUserIdAsync(string id, CancellationToken cancellationToken);
    Task<bool> IsExistsAsync(string code, CancellationToken cancellationToken);
}

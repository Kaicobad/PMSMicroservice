
namespace Pms360.Infrastructure.CurrentUser;
public class CurrentUserService : ICurrentUserService
{
    public string EmpCode { get; set; }
    public Guid UserId { get; set; }
    public string email { get; set; }
}

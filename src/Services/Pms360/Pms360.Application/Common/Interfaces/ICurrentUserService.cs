namespace Pms360.Application.Common.Interfaces;
public interface ICurrentUserService
{
    public string EmpCode { get; set; }
    public Guid UserId { get; set; }
    public string email { get; set; }
}

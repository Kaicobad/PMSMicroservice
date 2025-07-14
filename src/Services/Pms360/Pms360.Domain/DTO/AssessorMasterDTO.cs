using Pms360.Domain.Entities;

namespace Pms360.Domain.DTO;
public class AssessorMasterDTO
{
    public Guid AssessorMasterId { get; set; }
    public Guid ClientId { get; set; }
    public bool IsForUser { get; set; }
    public bool IsForUnit { get; set; }
    public bool IsForDepartment { get; set; }
    public bool IsForSection { get; set; }
    public bool IsForWing { get; set; }
    public bool IsForTeam { get; set; }
    public virtual ICollection<AssessorTypeMapDTO> AssessorTypeMaps { get; set; } = [];
    public virtual ICollection<AssessorUserMapDTO> AssessorUserMaps { get; set; } = [];
}

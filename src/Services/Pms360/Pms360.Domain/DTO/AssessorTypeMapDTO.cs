using Pms360.Domain.Entities;

namespace Pms360.Domain.DTO;
public class AssessorTypeMapDTO
{
    public Guid AssessorTypeMapId { get; set; }
    public Guid AssessorMasterId { get; set; }
    public AssessorMasterDTO AccessorMaster { get; set; }
    public Guid AssessorTypeId { get; set; }
    public AssessorTypeDTO AssessorType { get; set; }
    public virtual ICollection<AssessorUserMapDTO> AssessorUserMaps { get; set; } = [];
}

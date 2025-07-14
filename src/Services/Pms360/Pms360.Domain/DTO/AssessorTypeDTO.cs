using Pms360.Domain.Entities;

namespace Pms360.Domain.DTO;
public class AssessorTypeDTO
{
    public Guid TypeId { get; set; }
    public string TypeName { get; set; }
    public string Description { get; set; }
    public virtual ICollection<AssessorTypeMapDTO> AssessorTypeMaps { get; set; } = [];
}

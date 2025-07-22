namespace Pms360.Domain.Entities;

public partial class AssessorTypeMap : BaseEntity
{
    public Guid AssessorTypeMapId { get; set; }
    public Guid AssessorMasterId { get; set; }
    public Guid AssessorTypeId { get; set; }
    public virtual AssessorMaster AssessorMaster { get; set; }
    public virtual AssessorType AssessorType { get; set; }
    public virtual ICollection<AssessorUserMap> AssessorUserMaps { get; set; } = new List<AssessorUserMap>();
}

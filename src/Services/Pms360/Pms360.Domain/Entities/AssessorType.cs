namespace Pms360.Domain.Entities;

public partial class AssessorType : BaseEntity
{
    public Guid TypeId { get; set; }
    public string TypeName { get; set; }
    public string Description { get; set; }
    public virtual ICollection<AssessorTypeMap> AssessorTypeMaps { get; set; } = new List<AssessorTypeMap>();
}

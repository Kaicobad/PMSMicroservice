namespace Pms360.Domain.Entities;

public partial class AssessorMaster : BaseEntity
{
    public Guid AssessorMasterId { get; set; }

    public Guid ClientId { get; set; }

    public bool IsForUser { get; set; }

    public bool IsForUnit { get; set; }

    public bool IsForDepartment { get; set; }

    public bool IsForSection { get; set; }

    public bool IsForWing { get; set; }

    public bool IsForTeam { get; set; }

    public virtual ICollection<AssessorTypeMap> AssessorTypeMaps { get; set; } = new List<AssessorTypeMap>();

    public virtual ICollection<PmscycleDetail> PmscycleDetails { get; set; } = new List<PmscycleDetail>();
}

namespace Pms360.Domain.Entities;

public partial class PmscycleDetail : BaseEntity
{
    public Guid CycleDetailsId { get; set; }

    public Guid CycleId { get; set; }

    public Guid AssessorMasterId { get; set; }

    public virtual AssessorMaster AssessorMaster { get; set; }

    public virtual Pmscycle Cycle { get; set; }

    public virtual ICollection<PmscycleDetailsWithCriteriaMapping> PmscycleDetailsWithCriteriaMappings { get; set; } = new List<PmscycleDetailsWithCriteriaMapping>();
}

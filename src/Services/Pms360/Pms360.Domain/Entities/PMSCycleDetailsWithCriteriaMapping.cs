namespace Pms360.Domain.Entities;

public partial class PmscycleDetailsWithCriteriaMapping : BaseEntity
{
    public Guid CycleDetailsCriteriaMappingId { get; set; }

    public Guid? CycleDetailsId { get; set; }

    public Guid? CriteriaId { get; set; }

    public virtual EvaluationCriterion Criteria { get; set; }

    public virtual PmscycleDetail CycleDetails { get; set; }
}

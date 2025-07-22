namespace Pms360.Domain.Entities;

public partial class EvaluationCriterion : BaseEntity
{
    public Guid CriteriaId { get; set; }

    public string Title { get; set; }

    public string Description { get; set; }

    public int? DepartmentId { get; set; }

    public int? DesignationId { get; set; }

    public virtual ICollection<CriteriaScale> CriteriaScales { get; set; } = new List<CriteriaScale>();

    public virtual ICollection<EvaluationResponse> EvaluationResponses { get; set; } = new List<EvaluationResponse>();

    public virtual ICollection<PmscycleDetailsWithCriteriaMapping> PmscycleDetailsWithCriteriaMappings { get; set; } = new List<PmscycleDetailsWithCriteriaMapping>();
}

namespace Pms360.Domain.Entities;

public partial class CriteriaScale : BaseEntity
{
    public Guid ScaleId { get; set; }

    public Guid? CriteriaId { get; set; }

    public string Label { get; set; }

    public int? ScoreValue { get; set; }

    public virtual EvaluationCriterion Criteria { get; set; }
}

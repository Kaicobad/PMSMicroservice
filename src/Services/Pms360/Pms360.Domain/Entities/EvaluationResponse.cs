namespace Pms360.Domain.Entities;

public partial class EvaluationResponse  : BaseEntity
{
    public Guid ResponseId { get; set; }

    public Guid AssessorUserMapId { get; set; }

    public Guid CriteriaId { get; set; }

    public int? Score { get; set; }

    public string Comment { get; set; }

    public virtual AssessorUserMap AssessorUserMap { get; set; }

    public virtual EvaluationCriterion Criteria { get; set; }
}

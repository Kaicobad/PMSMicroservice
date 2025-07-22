namespace Pms360.Domain.Entities;

public partial class AssessorUserMap : BaseEntity
{
    public Guid AssessorUserMapId { get; set; }

    public Guid AssessorTypeMapId { get; set; }

    public Guid UserId { get; set; }
    public virtual AssessorTypeMap AssessorTypeMap { get; set; }

    public virtual ICollection<EvaluationResponse> EvaluationResponses { get; set; } = new List<EvaluationResponse>();
}

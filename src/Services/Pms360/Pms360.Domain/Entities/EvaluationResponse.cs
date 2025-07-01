namespace Pms360.Domain.Entities;
public class EvaluationResponse : BaseEntity
{
    [Required]
    [Key]
    public int ResponseId { get; set; }
    public Guid AssessorId { get; set; }
    public Guid CriteriaId { get; set; }
    public int Score { get; set; }
    public string Comment { get; set; }
    [ForeignKey("AssessorId")]
    public virtual PMSAssessor Assessor { get; set; }

    [ForeignKey("CriteriaId")]
    public virtual EvaluationCriteria Criteria { get; set; }
}

namespace Pms360.Domain.Entities;
public class PMSCycle : BaseEntity
{
    [Required]
    [Key]
    public Guid CycleId { get; set; }
    public string Title { get; set; }
    public Guid PMSTypeId { get; set; }
    public Guid PMSDurationTypeId { get; set; }
    public DateOnly StartDate { get; set; }
    public DateOnly EndDate { get; set; }

    [ForeignKey("PMSTypeId")]
    public virtual PMSType PMSType { get; set; }

    [ForeignKey("PMSDurationTypeId")]
    public virtual PMSDurationType PMSDurationType { get; set; }
    public virtual ICollection<PMSCycleDetails> CycleDetails { get; set; }
    public virtual ICollection<PMSAssessor> Assessors { get; set; }
    public virtual ICollection<EvaluationSummary> EvaluationSummaries { get; set; }
}

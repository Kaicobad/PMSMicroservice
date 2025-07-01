namespace Pms360.Domain.Entities;
public class EvaluationSummary :BaseEntity
{
    [Required]
    [Key]
    public Guid SummaryId { get; set; }
    public Guid CycleId { get; set; }
    public long EmpId { get; set; }
    public decimal AverageScore { get; set; }
    public decimal FinalRatingPercentage { get; set; }
    public string FinalComment { get; set; }
    public int FinalizedBy { get; set; }
    public DateTime FinalizedDate { get; set; }

    [ForeignKey("CycleId")]
    public virtual PMSCycle Cycle { get; set; }
}

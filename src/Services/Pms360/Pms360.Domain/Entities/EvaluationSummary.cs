namespace Pms360.Domain.Entities;

public partial class EvaluationSummary  : BaseEntity
{
    public Guid SummaryId { get; set; }

    public Guid? CycleId { get; set; }

    public Guid? EmpId { get; set; }

    public decimal? AverageScore { get; set; }

    public decimal? FinalRatingPercentage { get; set; }

    public string FinalComment { get; set; }

    public int? FinalizedBy { get; set; }

    public DateTime? FinalizedDate { get; set; }

    public virtual Pmscycle Cycle { get; set; }
}

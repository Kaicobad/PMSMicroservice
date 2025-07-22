namespace Pms360.Domain.Entities;

public partial class Pmscycle  : BaseEntity
{
    public Guid CycleId { get; set; }

    public string Title { get; set; }

    public Guid PmstypeId { get; set; }

    public Guid PmsdurationTypeId { get; set; }

    public DateOnly StartDate { get; set; }

    public DateOnly EndDate { get; set; }

    public virtual ICollection<EvaluationSummary> EvaluationSummaries { get; set; } = new List<EvaluationSummary>();

    public virtual ICollection<PmscycleDetail> PmscycleDetails { get; set; } = new List<PmscycleDetail>();

    public virtual PmsdurationType PmsdurationType { get; set; }

    public virtual Pmstype Pmstype { get; set; }
}

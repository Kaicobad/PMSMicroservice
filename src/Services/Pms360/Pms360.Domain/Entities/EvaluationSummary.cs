using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pms360.Domain.Entities;
public class EvaluationSummary :BaseEntity
{
    public Guid SummaryId { get; set; }
    public Guid? CycleId { get; set; }
    public int? EmployeeId { get; set; }
    public decimal? AverageScore { get; set; }
    public decimal? FinalRatingPercentage { get; set; }
    public string? FinalComment { get; set; }
    public int? FinalizedBy { get; set; }
    public DateTime? FinalizedDate { get; set; }

    public PMSCycle? Cycle { get; set; }
}

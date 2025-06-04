using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pms360.Domain.Entities;
public class PMSCycle : BaseEntity
{
    public Guid CycleId { get; set; }
    public string? Title { get; set; }
    public Guid PMSTypeId { get; set; }
    public Guid? PMSDurationTypeId { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }

    public PMSType? PMSType { get; set; }
    public PMSDurationType? PMSDurationType { get; set; }

    public ICollection<PMSCycleDetails>? CycleDetails { get; set; }
    public ICollection<PMSAssessor>? Assessors { get; set; }
    public ICollection<EvaluationSummary>? EvaluationSummaries { get; set; }
}

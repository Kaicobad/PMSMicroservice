using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pms360.Domain.Entities;
public class PMSCycleDetailsWithCriteriaMapping
{
    public Guid CycleDetailsCriteriaMappingId { get; set; }
    public Guid? CycleDetailsId { get; set; }
    public Guid? CriteriaId { get; set; }

    public PMSCycleDetails? CycleDetails { get; set; }
    public EvaluationCriteria? Criteria { get; set; }
}

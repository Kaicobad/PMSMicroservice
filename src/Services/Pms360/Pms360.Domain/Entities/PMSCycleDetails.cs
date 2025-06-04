using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pms360.Domain.Entities;
public class PMSCycleDetails :BaseEntity
{
    [Required]
    public Guid CycleDetailsId { get; set; }
    [Required]
    public Guid? CycleId { get; set; }
    [Required]
    public long? EmpId { get; set; }

    public PMSCycle? Cycle { get; set; }
    public ICollection<PMSCycleDetailsWithCriteriaMapping>? CriteriaMappings { get; set; }
}

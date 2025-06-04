using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pms360.Domain.Entities;
public class PMSAssessor : BaseEntity
{
    public Guid AssessorId { get; set; }
    public Guid? CycleId { get; set; }
    public int? AssesseeEmpId { get; set; } // Fixed spelling error and corrected syntax  
    public int? AssessorEmpId { get; set; }
    public int? AssessorTypeId { get; set; }
    public PMSCycle? Cycle { get; set; }
    public ICollection<EvaluationResponse>? Responses { get; set; }
}

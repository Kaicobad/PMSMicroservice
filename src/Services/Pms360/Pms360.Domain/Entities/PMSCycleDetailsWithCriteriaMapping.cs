using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pms360.Domain.Entities;
public class PMSCycleDetailsWithCriteriaMapping
{
    [Required]
    [Key]
    public Guid CycleDetailsCriteriaMappingId { get; set; }
    public Guid CycleDetailsId { get; set; }
    public Guid CriteriaId { get; set; }
    [ForeignKey("CycleDetailsId")]
    public virtual PMSCycleDetails CycleDetails { get; set; }

    [ForeignKey("CriteriaId")]
    public virtual EvaluationCriteria Criteria { get; set; }
}

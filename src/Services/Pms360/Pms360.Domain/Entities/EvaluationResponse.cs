using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pms360.Domain.Entities;
public class EvaluationResponse : BaseEntity
{
    [Required]
    [Key]
    public int ResponseId { get; set; }
    public Guid AssessorId { get; set; }
    public Guid CriteriaId { get; set; }
    public int Score { get; set; }
    public string Comment { get; set; }
    public PMSAssessor Assessor { get; set; }
    public EvaluationCriteria Criteria { get; set; }
}

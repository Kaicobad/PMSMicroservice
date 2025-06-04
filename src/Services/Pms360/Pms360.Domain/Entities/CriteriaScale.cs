using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pms360.Domain.Entities;
public class CriteriaScale : BaseEntity
{
    [Required]
    public int ScaleId { get; set; }
    [Required]
    public Guid? CriteriaId { get; set; }
    public string? Label { get; set; }
    public int ScoreValue { get; set; }

    public EvaluationCriteria? Criteria { get; set; }
}

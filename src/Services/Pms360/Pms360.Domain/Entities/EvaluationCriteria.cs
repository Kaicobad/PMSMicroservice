using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pms360.Domain.Entities;
public class EvaluationCriteria : BaseEntity
{
    [Required]
    [Key]
    public Guid CriteriaId { get; set; }
    public string Title { get; set; }
    [StringLength(500)]
    public string Description { get; set; }
    public int DepartmentId { get; set; }
    public int DesignationId { get; set; }

    public virtual ICollection<CriteriaScale> CriteriaScales { get; set; } = [];

    public virtual ICollection<EvaluationResponse> Responses { get; set; } = [];
}

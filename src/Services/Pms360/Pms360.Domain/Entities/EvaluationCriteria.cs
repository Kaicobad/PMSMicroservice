﻿namespace Pms360.Domain.Entities;
public class EvaluationCriteria : BaseEntity
{
    [Required]
    [Key]
    public Guid CriteriaId { get; set; }
    public string Title { get; set; }
    [StringLength(500)]
    public string Description { get; set; }
    public int UnitId { get; set; }
    public int DepartmentId { get; set; }
    public int DesignationId { get; set; }

    public virtual ICollection<CriteriaScale> CriteriaScales { get; set; } = new List<CriteriaScale>();

    public virtual ICollection<EvaluationResponse> Responses { get; set; } = new List<EvaluationResponse>();
}

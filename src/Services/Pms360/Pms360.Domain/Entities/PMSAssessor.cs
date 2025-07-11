﻿namespace Pms360.Domain.Entities;
public class PMSAssessor : BaseEntity
{
    [Required]
    [Key]
    public Guid AssessorId { get; set; }
    public Guid? CycleId { get; set; }
    public long AssessorEmpId { get; set; }
    public Guid AssessorTypeId { get; set; }
    [ForeignKey("CycleId")]
    public PMSCycle Cycle { get; set; }

    [ForeignKey("AssessorTypeId")]
    public virtual AssessorType AssessorType { get; set; }
    public virtual ICollection<EvaluationResponse> EvaluationResponses { get; set; }
}

namespace Pms360.Domain.Entities;
public class PMSCycleDetails :BaseEntity
{
    [Required]
    [Key]
    public Guid CycleDetailsId { get; set; }
    [Required]
    public Guid CycleId { get; set; }
    [Required]
    public long EmpId { get; set; }


    [ForeignKey("CycleId")]
    public virtual PMSCycle Cycle { get; set; }
    public virtual ICollection<PMSAssessorDetails> PMSAssessorDetails { get; set; } = [];
    public virtual ICollection<PMSCycleDetailsWithCriteriaMapping> CriteriaMappings { get; set; }
}

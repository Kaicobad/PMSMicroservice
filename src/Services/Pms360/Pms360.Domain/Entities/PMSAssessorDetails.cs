namespace Pms360.Domain.Entities;
public class PMSAssessorDetails
{
    [Required]
    [Key]
    public Guid AssessorDetailsId { get; set; }
    public Guid AssessorId { get; set; }

    public Guid CycleDetailsId { get; set; }

    [ForeignKey("AssessorId")]
    public virtual PMSAssessor Assessor { get; set; }

    [ForeignKey("CycleDetailsId")]
    public virtual PMSCycleDetails CycleDetails { get; set; }
}

namespace Pms360.Domain.Entities;
public class AssessorType :BaseEntity
{
    [Required]
    [Key]
    public Guid TypeId { get; set; }
    [Required]
    [StringLength(100)]
    public string TypeName { get; set; }
    [StringLength(200)]
    public string Description { get; set; }
    public virtual ICollection<PMSAssessor> PMSAssessors { get; set; } = [];
}


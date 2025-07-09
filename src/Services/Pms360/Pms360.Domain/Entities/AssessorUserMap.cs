namespace Pms360.Domain.Entities;
public class AssessorUserMap : BaseEntity
{
    [Key]
    [Required]
    public Guid AssessorUserMapId { get; set; } 
    [Required]
    public Guid AssessorTypeMapId { get; set; }

    [ForeignKey(nameof(AssessorTypeMapId))]
    public AssessorTypeMap AssessorTypeMap { get; set; }
    [Required]
    public Guid AssessorMasterId { get; set; }
    [ForeignKey(nameof(AssessorMasterId))]
    public AssessorMaster AccessorMaster { get; set; }
    [Required]
    public Guid UserId { get; set; }

}

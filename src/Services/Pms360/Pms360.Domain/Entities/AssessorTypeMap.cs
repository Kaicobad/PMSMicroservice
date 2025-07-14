namespace Pms360.Domain.Entities;
public class AssessorTypeMap : BaseEntity
{
    [Key]
    [Required]
    public Guid AssessorTypeMapId { get; set; }
    [Required]
    public Guid AssessorMasterId { get; set; }
    [ForeignKey(nameof(AssessorMasterId))]
    public AssessorMaster AccessorMaster { get; set; }
    [Required]
    public Guid AssessorTypeId { get; set; }
    [ForeignKey(nameof(AssessorTypeId))]
    public AssessorType AssessorType { get; set; }
    public virtual ICollection<AssessorUserMap> AssessorUserMaps { get; set; } = new List<AssessorUserMap>();

}

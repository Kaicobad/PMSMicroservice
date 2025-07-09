namespace Pms360.Domain.Entities;
public class AssessorMaster : BaseEntity
{
    [Key]
    [ForeignKey(nameof(AssessorMasterId))]
    public Guid AssessorMasterId { get; set; }
    [Required]
    public Guid ClientId { get; set; }
    public bool IsForUser { get; set; }
    public bool IsForUnit { get; set; }
    public bool IsForDepartment { get; set; }
    public bool IsForSection { get; set; }
    public bool IsForWing { get; set; }
    public bool IsForTeam { get; set; }

    public virtual ICollection<AssessorTypeMap> AssessorTypeMaps { get; set; } = new List<AssessorTypeMap>();
    public virtual ICollection<AssessorUserMap> AssessorUserMaps { get; set; } = new List<AssessorUserMap>();
}

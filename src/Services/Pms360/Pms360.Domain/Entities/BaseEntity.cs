namespace Pms360.Domain.Entities;
public class BaseEntity
{
    [Required]
    public Guid CreatedById { get; set; }
    [Required]
    public DateTime CreatedOn { get; set; }
    public Guid UpdatedBy { get; set; }
    public DateTime UpdatedOn { get; set; }
    public Guid DeletedById { get; set; }
    public DateTime DeletedOn { get; set; }
    [Required]
    public bool IsActive { get; set; } = true;
}

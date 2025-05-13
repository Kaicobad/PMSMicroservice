
using Pms360.Domain.Abstractions;

namespace Pms360.Domain.Entities;
[Table("Pms360TypeReference")]
public class Pms360TypeReference :Aggregate<Guid>
{
    [Required]
    [Column("Name")]
    [StringLength(50)]
    public required string Name { get; set; }

    [Column("Description")]
    [StringLength(200)]
    public string? Description { get; set; }

    [Required]
    [Column("IsActive")]
    public bool IsActive { get; set; } = false;
}


namespace Pms360.API.Entities;

[Table("Pms360TypeReference")]
public class Pms360TypeReference  :BaseEntity
{
    [Key]
    [Column("Id")]
    public required Guid Id { get; set; }

    [Required]
    [Column("Name")]
    [StringLength(50)]
    public required string Name { get; set; }

    [Column("Description")]
    [StringLength(200)]
    public string? Description { get; set; }

    [Required]
    [Column("IsActive")]
    public bool IsActive { get; set; }

}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pms360.Domain.Models;
public class Pms360TypeReference : Aggregate<Guid>
{
    [Required]
    [StringLength(100)]
    public required string Name { get; set; }
    [StringLength(200)]
    public string? Description { get; set; }
    [Required]
    [Column("IsActive")]
    public bool IsActive { get; set; } = false;
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pms360.Domain.Entities;
public class Pms360TypeReference : BaseEntity
{
    [Required]
    [StringLength(100)]
    public required string Name { get; set; }
    [StringLength(200)]
    public string? Description { get; set; }
}

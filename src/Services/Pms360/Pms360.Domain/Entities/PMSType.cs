using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pms360.Domain.Entities;
public class PMSType : BaseEntity
{
    [Required]
    [Key]
    public Guid TypeId { get; set; }
    [Required]
    [StringLength(100)]
    public required string Name { get; set; }
    [StringLength(200)]
    public string Description { get; set; }

    public virtual ICollection<PMSCycle> PMSCycles { get; set; } = [];
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pms360.Domain.Entities;
public class BaseEntity
{
    [Required]
    public Guid CreatedById { get; set; }
    [Required]
    public DateTime CreatedOn { get; set; }
    public Guid? ModifiedById { get; set; }
    public DateTime? ModifiedOn { get; set; }
    public Guid? DeletedById { get; set; }
    public DateTime? DeletedOn { get; set; }
    [Required]
    public bool IsActive { get; set; }
}

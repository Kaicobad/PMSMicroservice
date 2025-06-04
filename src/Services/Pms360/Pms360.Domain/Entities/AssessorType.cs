using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pms360.Domain.Entities;
public class AssessorType :BaseEntity
{
    [Required]
    public Guid TypeId { get; set; }
    [Required]
    public string? TypeName { get; set; }; 
}

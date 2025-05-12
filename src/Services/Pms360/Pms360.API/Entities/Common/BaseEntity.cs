using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Pms360.API.Entities.Common;

public class BaseEntity
{
    [Required]
    [Column("CreatedById")]
    public Guid CreatedById { get; set; }
    [Required]
    [Column("CreatedOn")]
    public DateTime CreatedOn { get; set; }

    [Column("ModifiedById")]
    public Guid? ModifiedById { get; set; }

    [Column("ModifiedOn")]
    public DateTime? ModifiedOn { get; set; }

    [Column("DeletedById")]
    public Guid? DeletedById { get; set; }

    [Column("DeletedOn")]
    public DateTime? DeletedOn { get; set; }
}

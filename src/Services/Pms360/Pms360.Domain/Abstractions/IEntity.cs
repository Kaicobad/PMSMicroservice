
using System.ComponentModel.DataAnnotations;


namespace Pms360.Domain.Abstractions;
public interface IEntity<T> : IEntity
{
    public T Id { get; set; }
}
public interface IEntity
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

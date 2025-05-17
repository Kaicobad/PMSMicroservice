namespace Pms360.Domain.Abstractions;
public abstract class Entity<T> : IEntity<T>
{
    public T Id { get; set; } = default!;

    [Required]
    public Guid CreatedById { get; set; }
    [Required]
    public DateTime CreatedOn { get; set; }
    public Guid? ModifiedById { get; set; }
    public DateTime? ModifiedOn { get; set; }
    public Guid? DeletedById { get; set; }
    public DateTime? DeletedOn { get; set; }
}

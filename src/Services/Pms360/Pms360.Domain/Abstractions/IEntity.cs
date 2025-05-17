namespace Pms360.Domain.Abstractions;
public interface IEntity<T> : IEntity
{
    public T Id { get; set; }
}
public interface IEntity
{
    [Required]
    public Guid CreatedById { get; set; }
    [Required]
    public DateTime CreatedOn { get; set; }
    public Guid? ModifiedById { get; set; }
    public DateTime? ModifiedOn { get; set; }
    public Guid? DeletedById { get; set; }
    public DateTime? DeletedOn { get; set; }
}

namespace Pms360.Domain.Entities;

public partial class PmsdurationType  : BaseEntity
{
    public Guid DurationTypeId { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    public virtual ICollection<Pmscycle> Pmscycles { get; set; } = new List<Pmscycle>();
}

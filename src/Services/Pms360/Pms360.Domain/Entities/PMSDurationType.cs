﻿namespace Pms360.Domain.Entities;
public class PMSDurationType :BaseEntity
{
    [Required]
    [Key]
    public Guid DurationTypeId { get; set; }
    [Required]
    [StringLength(100)]
    public required string Name { get; set; }
    [StringLength(200)]
    public string Description { get; set; }
    public virtual ICollection<PMSCycle> PMSCycles { get; set; }
}

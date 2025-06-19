using System.ComponentModel.DataAnnotations;

namespace Pms360.Application.Models.Requests;
public class UpdatePMSTypeRequest
{
    public Guid TypeId { get; set; }
    public required string Name { get; set; }
    public string Description { get; set; }
}

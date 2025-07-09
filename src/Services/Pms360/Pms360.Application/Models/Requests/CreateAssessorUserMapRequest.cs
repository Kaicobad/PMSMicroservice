using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pms360.Application.Models.Requests;
public class CreateAssessorUserMapRequest
{
    public Guid AssessorTypeMapId { get; set; }
    public Guid AssessorMasterId { get; set; }
    public Guid UserId { get; set; }
}

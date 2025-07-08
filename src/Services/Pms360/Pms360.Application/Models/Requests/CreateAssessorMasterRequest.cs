using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pms360.Application.Models.Requests;
public class CreateAssessorMasterRequest
{
    public Guid ClientId { get; set; } 
    public bool IsForUser { get; set; } = false;
    public bool IsForUnit { get; set; } = false;
    public bool IsForDepartment { get; set; } = false;
    public bool IsForSection { get; set; } = false;
    public bool IsForWing { get; set; } = false;
    public bool IsForTeam { get; set; } = false;
}

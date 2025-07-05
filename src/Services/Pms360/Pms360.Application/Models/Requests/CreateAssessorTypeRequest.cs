namespace Pms360.Application.Models.Requests;
public record CreateAssessorTypeRequest
{
    public string TypeName { get; set; }
    public string Description { get; set; }
}

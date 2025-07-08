namespace Pms360.Application.Models.Requests;
public class CreateAssessorTypeMapRequest
{
    public Guid AssessorMasterId { get; set; }
    public Guid AssessorTypeId { get; set; }
}

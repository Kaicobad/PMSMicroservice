using Pms360.Domain.Entities;

namespace Pms360.Domain.DTO;
public class AssessorUserMapDTO
{
    public Guid AssessorUserMapId { get; set; }
    public Guid AssessorTypeMapId { get; set; }

    //public AssessorTypeMapDTO AssessorTypeMap { get; set; }
    public Guid AssessorMasterId { get; set; }
    //public AssessorMasterDTO AccessorMaster { get; set; }
    public Guid UserId { get; set; }
    public string Name { get; set; }
    public string EmpCode { get; set; }
}

using System;
using System.Collections.Generic;

namespace Pms360.Domain.CoreERPEntities;

public partial class CommonDepartment
{
    public int DepartmentId { get; set; }

    public string DepartmentName { get; set; }

    public string DepartmentNameBan { get; set; }

    public string DepartmentShortName { get; set; }

    public bool IsActive { get; set; }

    public DateTime? EntryDate { get; set; }

    public int? EntryUserId { get; set; }

    public string TerminalId { get; set; }
}

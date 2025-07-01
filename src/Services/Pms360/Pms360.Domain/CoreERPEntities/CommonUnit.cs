using System;
using System.Collections.Generic;

namespace Pms360.Domain.CoreERPEntities;

public partial class CommonUnit
{
    public int UnitId { get; set; }

    public int CompanyId { get; set; }

    public string UnitName { get; set; }

    public string UnitShortName { get; set; }

    public string UnitNameBan { get; set; }

    public string UnitFullName { get; set; }

    public string UnitFullNameBan { get; set; }

    public string UnitAddress { get; set; }

    public string Dmcode { get; set; }

    public bool IsActive { get; set; }

    public string UserId { get; set; }

    public string TerminalId { get; set; }

    public int? UnitTypeId { get; set; }

    public DateTime? EntryDate { get; set; }

    public DateTime? UpdateDate { get; set; }

    public int? UpdateBy { get; set; }

    public int? IsHrmunit { get; set; }

    public int? ZoneId { get; set; }

    public int? LocationId { get; set; }

    public string UnitContact { get; set; }

    public DateTime? MigrationDateApparel { get; set; }
}

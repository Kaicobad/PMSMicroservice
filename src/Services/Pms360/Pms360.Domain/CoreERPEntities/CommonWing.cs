using System;
using System.Collections.Generic;

namespace Pms360.Domain.CoreERPEntities;

public partial class CommonWing
{
    public int WingId { get; set; }

    public string WingName { get; set; }

    public string WingNameBan { get; set; }

    public int? IsLine { get; set; }

    /// <summary>
    /// If this section is a Line then Line Category= StandardLine=1,MiniLine=2
    /// </summary>
    public int? LineCategory { get; set; }

    public bool IsActive { get; set; }
}

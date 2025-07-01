using System;
using System.Collections.Generic;

namespace Pms360.Domain.CoreERPEntities;

public partial class CommonTeam
{
    public int TeamId { get; set; }

    public string TeamName { get; set; }

    public string TeamNameBan { get; set; }

    public int? IsLine { get; set; }

    /// <summary>
    /// If this section is a Line then Line Category= StandardLine=1,MiniLine=2
    /// </summary>
    public int? LineCategory { get; set; }

    public bool IsActive { get; set; }
}

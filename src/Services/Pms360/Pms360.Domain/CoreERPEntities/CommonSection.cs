using System;
using System.Collections.Generic;

namespace Pms360.Domain.CoreERPEntities;

public partial class CommonSection
{
    public int SectionId { get; set; }

    public string SectionName { get; set; }

    public string SectionNameBan { get; set; }

    public int? IsLine { get; set; }

    /// <summary>
    /// If this section is a Line then Line Category= StandardLine=1,MiniLine=2
    /// </summary>
    public int? LineCategory { get; set; }

    public bool IsActive { get; set; }

    public DateTime? EntryDate { get; set; }

    public int? EntryUserId { get; set; }

    public string TerminalId { get; set; }

    public string SectionShortName { get; set; }
}

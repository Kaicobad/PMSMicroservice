using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pms360.Application.Models.Requests;
public class GetPmsCycleByTypeAndDurationRequest
{
    public Guid PMSTypeId { get; set; }
    public Guid PMSDurationTypeId { get; set; }
    public int PageNumber { get; set; }
    public int PageSize { get; set; } = 10;

}

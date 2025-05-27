using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pms360.Domain.Entities;

namespace Pms360.Domain.Repositories;
public interface IPms360PeriodReferenceRepository
{
    Task<IEnumerable<Pms360PeriodReference>> GetAllPeriodsAsync();
}

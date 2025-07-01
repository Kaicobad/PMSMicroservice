using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pms360.Application.Features.CommonUnits;
public interface ICommonUnitService
{
    Task<List<CommonUnit>> GetAllAsync(CancellationToken cancellationToken);
    Task<CommonUnit> GetByIdAsync(int UnitId, CancellationToken cancellationToken);
    Task<List<CommonUnit>> GetByCompanyId(int CompanyId, CancellationToken cancellationToken);
}

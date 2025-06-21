using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pms360.Domain.Entities;

namespace Pms360.Application.Features.PMSTypes;
public interface IPMSTypesService
{
    Task<Guid> CreateAsync(PMSType pmsType, CancellationToken cancellationToken);
    Task<PMSType> UpdateAsync(PMSType pmsType, CancellationToken cancellationToken);
    Task<int> DeleteAsync(Guid id, CancellationToken cancellationToken);
    Task<PMSType> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    Task<List<PMSType>> GetAll(CancellationToken cancellationToken);
    Task<List<PMSType>> GetAllNoFilter(CancellationToken cancellationToken);
    Task<bool> IsExistsAsync(Guid id, CancellationToken cancellationToken);
    Task<bool> IsNameExistsAsync(string name, CancellationToken cancellationToken);
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pms360.Application.Features.PMSDurationTypes;
public interface IPMSDurationTypeService
{
    Task<Guid> CreateAsync(PmsdurationType pmsDurationType, CancellationToken cancellationToken);
    Task<PmsdurationType> UpdateAsync(PmsdurationType pmsDurationType, CancellationToken cancellationToken);
    Task<int> DeleteAsync(Guid id, CancellationToken cancellationToken);
    Task<PmsdurationType> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    Task<List<PmsdurationType>> GetAll(CancellationToken cancellationToken);
    Task<List<PmsdurationType>> GetAllNoFilter(CancellationToken cancellationToken);
    Task<bool> IsExistsAsync(Guid id, CancellationToken cancellationToken);
    Task<bool> IsNameExistsAsync(string name, CancellationToken cancellationToken);
}

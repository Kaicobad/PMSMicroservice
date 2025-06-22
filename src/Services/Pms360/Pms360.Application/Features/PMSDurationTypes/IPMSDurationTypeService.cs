using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pms360.Application.Features.PMSDurationTypes;
public interface IPMSDurationTypeService
{
    Task<Guid> CreateAsync(PMSDurationType pmsDurationType, CancellationToken cancellationToken);
    Task<PMSDurationType> UpdateAsync(PMSDurationType pmsDurationType, CancellationToken cancellationToken);
    Task<int> DeleteAsync(Guid id, CancellationToken cancellationToken);
    Task<PMSDurationType> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    Task<List<PMSDurationType>> GetAll(CancellationToken cancellationToken);
    Task<List<PMSDurationType>> GetAllNoFilter(CancellationToken cancellationToken);
    Task<bool> IsExistsAsync(Guid id, CancellationToken cancellationToken);
    Task<bool> IsNameExistsAsync(string name, CancellationToken cancellationToken);
}

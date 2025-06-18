using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pms360.Domain.Entities;

namespace Pms360.Application.Features.PMSTypes;
public interface IPMSTypesService
{
    Task<int> CreateAsync(PMSType pmsType);
    Task<PMSType> UpdateAsync(PMSType pmsType);
    Task<int> DeleteAsync(int id);
    Task<PMSType> GetByIdAsync(int id);
    Task<List<PMSType>> GetAll();
    Task<bool> IsExistsAsync(int id);
}

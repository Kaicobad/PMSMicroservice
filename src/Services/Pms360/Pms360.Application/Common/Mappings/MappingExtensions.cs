using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pms360.Application.Models.Pagination;

namespace Pms360.Application.Common.Mappings;
public static class MappingExtensions
{
    public class PaginationHelper
    {
        public static Task<PaginatedList<TDestination>> PaginatedListAsync<TDestination>(IQueryable<TDestination> queryable, int pageNumber, int pageSize) where TDestination : class
        {
            return PaginatedList<TDestination>.CreateAsync(queryable.AsNoTracking(), pageNumber, pageSize);
        }
    }

}

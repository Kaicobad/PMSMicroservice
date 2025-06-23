using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pms360.Application.Models.Pagination;

namespace Pms360.Application.Common.Mappings;
public static class MappingExtensions
{
    public async static Task<PaginatedList<TDestination>> PaginatedListAsync<TDestination>(this IQueryable<TDestination> queryable, int pageNumber, int pageSize) where TDestination : class
    {
        return await PaginatedList<TDestination>.CreateAsync(queryable.AsNoTracking(), pageNumber, pageSize);
    }

    public static Task<List<TDestination>> ProjectToListAsync<TDestination>(this IQueryable queryable) where TDestination : class
    {
        return queryable.ProjectToType<TDestination>().AsNoTracking().ToListAsync();
    }
}

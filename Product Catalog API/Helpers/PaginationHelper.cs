using Microsoft.EntityFrameworkCore;
using Product_Catalog_API.Endpoints.Common;

namespace Product_Catalog_API.Helpers;


using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;

public static class PaginationHelper
{
  
    public static async Task<PagedResult<TDestination>> PaginateAsync<TSource, TDestination>(
        IQueryable<TSource> query,
        IMapper mapper,
        int pageNumber,
        int pageSize)
    {
      
        pageNumber = pageNumber < 1 ? 1 : pageNumber;
        pageSize = pageSize > 50 ? 50 : pageSize;

      
        var totalCount = await query.CountAsync();

    
        var items = await query
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ProjectTo<TDestination>(mapper.ConfigurationProvider)
            .ToListAsync();

        return new PagedResult<TDestination>
        {
            Items = items,
            TotalCount = totalCount,
            PageNumber = pageNumber,
            PageSize = pageSize
        };
    }
}

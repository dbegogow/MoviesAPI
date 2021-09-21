using System.Linq;
using MoviesAPI.DTOs;

namespace MoviesAPI.Helpers
{
    public static class QueryableExtensions
    {
        public static IQueryable<T> Paginate<T>(this IQueryable<T> queryable, PaginationDto paginationDto)
            => queryable
                .Skip((paginationDto.Page - 1) * paginationDto.RecordsPerPage)
                .Take(paginationDto.RecordsPerPage);
    }
}

using MarketPlace.Domain.Common.Queries;

namespace MarketPlace.Persistence.Extensions;

/// <summary>
/// Provides extension methods for applying query specifications to IQueryable and IEnumerable collections.
/// </summary>
public static class LinqExtensions
{
    /// <summary>
    /// Applies pagination to and IQeryable data source.
    /// </summary>
    /// <typeparam name="TSource">The type of elements in the data source.</typeparam>
    /// <param name="sources">The IQueyable source to paginate.</param>
    /// <param name="filterPagination">Pagination options such as page token and page size.</param>
    /// <returns>An IQueryable representing the paginated subset of the oeiginal data source.</returns>
    public static IQueryable<TSource> ApplyPagination<TSource>(
        this IQueryable<TSource> sources,
        FilterPagination filterPagination)
    {
        return sources
            .Skip((int)((filterPagination.PageToken - 1) * filterPagination.PageSize))
            .Take((int)filterPagination.PageSize);
    }
}

using MarketPlace.Application.Identity.Models;
using MarketPlace.Domain.Common.Queries;

namespace MarketPlace.Application.Notifications.Models;

public class EmailTemplateFilter : FilterPagination
{
    /// <summary>
    /// Overrides base GetHashCode method
    /// </summary>
    /// <returns></returns>
    public override int GetHashCode()
    {
        var hashCode = new HashCode();

        hashCode.Add(PageToken);
        hashCode.Add(PageSize);

        return hashCode.ToHashCode();
    }

    /// <summary>
    /// Overrides base Equels method
    /// </summary>
    /// <param name="obj"></param>
    /// <returns></returns>
    public override bool Equals(object? obj) =>
        obj is EmailTemplateFilter filter
        && filter.GetHashCode() == GetHashCode();
}
